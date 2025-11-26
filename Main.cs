using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Saratov
{
    public partial class Main : Form
    {
        #region Initializations
        public BindingList<JobClass> jobs = new BindingList<JobClass>();
        //InputValidation inputValidation = new InputValidation();
        SaveLoad saveload = new SaveLoad();
        ClearJobs clearJobs = new ClearJobs();
        Checks check = new Checks();
        Specs specs = new Specs();
        RestartAsAdmin startAdmin = new RestartAsAdmin();
        CommandGenerator cmdGen = new CommandGenerator();
        //IdleMonitor idleMonitor = new IdleMonitor();
        //DriveInfo[] allDrives = DriveInfo.GetDrives();
        #endregion
        public Main() { InitializeComponent(); }

        private void Main_Load(object sender, EventArgs e)
        {
            lblElevation.Text = check.IsAdministrator();
            dgvJobs.DataSource = jobs;
            lblCoreThread.Text = "Cores / Threads: " + specs.coresCPU() + "C / " + specs.ThreadsCPU().ToString() + "T";
            lblAvailableMemory.Text = "Available Memory: " + specs.AvailableRAM() + "MB / " + specs.TotalRAM() + "MB";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Stop pressed
            if (bgWorker.IsBusy == true || btnStartStop.BackColor == Color.Red)
            {
                bgWorker.CancelAsync();
                lblState.Text = "State: Stopping";
                btnStartStop.BackColor = Color.Yellow;
                btnStartStop.Text = "---";
            }
            //Start Pressed
            else
            {
                if (dgvJobs.Rows.Count == 0)
                {
                    MessageBox.Show("Nothing to do.", "Info");
                    return;
                }

                lblState.Text = "State: Active";
                btnStartStop.BackColor = Color.Red;
                btnStartStop.Text = "Stop";

                bgWorker.RunWorkerAsync();
            }
        }

        #region Background Worker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Worker worker = new Worker();
            string program, action;
            string behaviour = gbBehaviour.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
            int currentJob = 0;
            bool bigJobSkip = false;
            string args = null;

            #region Validation (Disabled, check TODO.cs) 

            #endregion

            #region Space Check (!Untested!)
            foreach (JobClass job in jobs)
            {
                DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(job.Address));
                if (job.SizeBefore > driveInfo.AvailableFreeSpace / 1024 / 1024)
                {
                    if (MessageBox.Show("One or more jobs exceed the free space of the drive! \n" +
                                        "Leave those jobs for next run?", "Attention!",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    { bigJobSkip = true; break; }
                }
            }

            if (bigJobSkip)
                foreach (JobClass job in jobs)
                {
                    DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(job.Address));
                    if (job.SizeBefore > driveInfo.AvailableFreeSpace / 1024 / 1024)
                    {
                        job.State = "Skip";
                    }
                }
            #endregion

            while (currentJob < jobs.Count() && bgWorker.CancellationPending == false)
            {
                switch (behaviour)
                {
                    case "Normal":
                        {
                            #region Attempt to Determine Program
                            try
                            {
                                program = gbProgram.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
                            }
                            catch
                            {
                                MessageBox.Show("Please pick a program.", "Error");
                                return;
                            }
                            #endregion

                            #region Attempt to Determine Action
                            try
                            {
                                action = gbAction.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
                            }
                            catch
                            {
                                MessageBox.Show("Please select an action.", "Error");
                                return;
                            }
                            #endregion

                            #region Rearm of skipped jobs
                            if (jobs[currentJob].State == "Skip")
                            {
                                jobs[currentJob].State = "Queued";
                                break;
                            }
                            #endregion

                            jobs[currentJob].State = "Working...";

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                //dgvJobs.Refresh();

                                args = cmdGen.Prepare(
                                program, action,
                                cbPARAlgorithm.Text,
                                cbPARLevel.Text,
                                cbPARMemory.Text,
                                cbPARWordSize.Text,
                                cbPARThreads.Text,
                                cbPARFormat.Text,
                                jobs[currentJob],
                                lblACDeleteAfter.ForeColor
                                );

                                tbArgs.Text = args;
                            }));

                            worker.Start(jobs[currentJob], args, lblACSilent.ForeColor, program);

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                jobs[currentJob].SizeAfter = check.SizeOf(jobs[currentJob].Address + "." + cbPARFormat.Text);
                                jobs[currentJob].State = "DONE";
                                dgvJobs.Refresh();
                            }));

                            currentJob++;
                            break;
                        }
                    case "Brute Force":
                        {
                            {
                                if (jobs[currentJob].State == "Queued")
                                {
                                    this.Invoke(new MethodInvoker(delegate ()
                                    {
                                        Brute brute = new Brute();
                                        brute.Start(jobs[currentJob], lblACSilent.ForeColor);
                                        dgvJobs.Refresh();
                                        currentJob++;
                                    }));
                                }
                                else { currentJob++; }
                                break;
                            }
                        }
                }
            }
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblState.Text = "State: Inactive";
            btnStartStop.BackColor = Color.LimeGreen;
            btnStartStop.Text = "Start";
        }
        #endregion

        #region Self-Adjust (A adjusts B)

        #region Behaviour -> All or Most
        private void rbtnBBrute_CheckedChanged(object sender, EventArgs e)
        {
            rbtn7z.Enabled = false;
            rbtnFreeArc.Enabled = false;
            rbtnMCM.Enabled = false;
            rbtnBSC.Enabled = false;

            rbtnAdd.Enabled = false;
            rbtnExtract.Enabled = false;
            rbtnTest.Enabled = false;
        }

        private void rbtnBNormal_CheckedChanged(object sender, EventArgs e)
        {
            rbtn7z.Enabled = true;
            rbtnFreeArc.Enabled = false;
            rbtnMCM.Enabled = false;
            rbtnBSC.Enabled = true;
        }
        #endregion

        #region Program -> Action + Format
        private void rbtn7z_CheckedChanged(object sender, EventArgs e)
        {
            //Actions
            rbtnAdd.Enabled = true;
            rbtnExtract.Enabled = true;
            rbtnTest.Enabled = true;
            //Formats
            cbPARFormat.Items.Clear();
            cbPARFormat.Items.AddRange(new string[] { "7z", "bzip2", "gzip", "tar", "wim", "xz", "zip" });
        }

        private void rbtnBSC_CheckedChanged(object sender, EventArgs e)
        {
            //Actions
            rbtnAdd.Enabled = true;
            rbtnExtract.Enabled = true;
            rbtnTest.Enabled = false;
            //Format
            cbPARFormat.Items.Clear();
            cbPARFormat.Items.Add("bsc");
        }
        #endregion

        #region Action -> Parameter (On/Off)
        private void rbtnTest_CheckedChanged(object sender, EventArgs e)
        {
            cbPARFormat.Enabled = false;
            cbPARMemory.Enabled = false;
            cbPARLevel.Enabled = false;
            cbPARThreads.Enabled = false;
            cbPARWordSize.Enabled = false;
            cbPARAlgorithm.Enabled = false;
        }
        private void rbtnExtract_CheckedChanged(object sender, EventArgs e)
        {
            cbPARFormat.Enabled = false;
            cbPARMemory.Enabled = false;
            cbPARLevel.Enabled = false;
            cbPARThreads.Enabled = false;
            cbPARWordSize.Enabled = false;
            cbPARAlgorithm.Enabled = false;
        }
        private void rbtnAdd_CheckedChanged(object sender, EventArgs e)
        {
            switch (gbProgram.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag)
            {
                case "7zip":
                    {
                        cbPARFormat.Enabled = true;
                        cbPARMemory.Enabled = true;
                        cbPARLevel.Enabled = true;
                        cbPARThreads.Enabled = true;
                        cbPARWordSize.Enabled = true;
                        cbPARAlgorithm.Enabled = true;
                        break;
                    }
                case "FreeARC":
                    {
                        break;
                    }
                case "MCM":
                    {
                        break;
                    }
                case "BSC":
                    {
                        cbPARFormat.Enabled = true;
                        cbPARMemory.Enabled = true;
                        cbPARLevel.Enabled = false;
                        cbPARThreads.Enabled = false;
                        cbPARWordSize.Enabled = false;
                        cbPARAlgorithm.Enabled = true;
                        break;
                    }
            }
        }
        #endregion

        #region Format -> Algorythm
        private void cbPARFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFormat = cbPARFormat.Text;
            switch (selectedFormat)
            {
                case "7z":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "LZMA2", "LZMA", "PPMd", "BZip2" });
                        break;
                    }

                case "bzip2":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "BZip2" });
                        break;
                    }
                case "gzip":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "Deflate" });

                        break;
                    }
                case "tar":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "GNU", "POSIX" });
                        break;
                    }
                case "wim":
                    {
                        cbPARAlgorithm.Items.Clear();
                        //Only Exception
                        cbPARLevel.Items.Clear();
                        cbPARThreads.Items.Clear();
                        cbPARWordSize.Items.Clear();
                        cbPARMemory.Items.Clear();
                        //Consistantly inconsistant!
                        break;
                    }
                case "xz":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "LZMA2" });
                        break;
                    }
                case "zip":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "Deflate", "Deflate64", "BZip2", "LZMA", "PPMd" });
                        break;
                    }
                case "bsc":
                    {
                        cbPARAlgorithm.Items.Clear();
                        cbPARAlgorithm.Items.AddRange(new string[] { "BWT" });
                        //, "ST-n3", "ST-n4", "ST-n5", "ST-n6", "ST-n7", "ST-n8"
                        break;
                    }
            }
        }
        #endregion

        #region Algorythm -> Dictionary, Word, Level
        private void cbPARAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAlgorythm = cbPARAlgorithm.Text;
            switch (selectedAlgorythm)
            {
                #region 7zip
                case "LZMA2":
                    {
                        clearAll();
                        cbPARLevel.Items.AddRange(new object[] { 1, 3, 5, 7, 9 });
                        addThreads();
                        cbPARWordSize.Items.AddRange(new object[] { 8, 12, 16, 24, 32, 48, 64, 96, 128, 192, 256, 273 });
                        cbPARMemory.Items.AddRange(new object[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 384, 512, 768, 1024, 1536, 2048, 3072, 3840 });

                        break;
                    }

                case "LZMA":
                    {
                        clearAll();
                        cbPARLevel.Items.AddRange(new object[] { 1, 3, 5, 7, 9 });
                        addThreads();
                        cbPARMemory.Items.AddRange(new object[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 384, 512, 768, 1024, 1536, 2048, 3072, 3840 });
                        cbPARWordSize.Items.AddRange(new object[] { 8, 12, 16, 24, 32, 48, 64, 96, 128, 192, 256, 273 });
                        break;
                    }
                case "PPMd":
                    {
                        clearAll();
                        cbPARLevel.Items.AddRange(new object[] { 1, 3, 5, 7, 9 });
                        //ERRORS OUT WITH ANYTHING ELSE
                        //cbPARThreads.Items.Add(1);
                        //cbPARMemory.Items.AddRange(new object[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 384, 512, 768, 1024 });
                        //cbPARWordSize.Items.AddRange(new object[] { 2, 3, 4, 5, 6, 7, 8, 16, 24, 32 });
                        break;
                    }
                case "BZip2":
                    {
                        clearAll();
                        cbPARLevel.Items.AddRange(new object[] { 1, 3, 5, 7, 9 });
                        addThreads();
                        cbPARMemory.Items.Add("900KB");
                        break;
                    }
                case "Deflate":
                    {
                        clearAll();

                        cbPARLevel.Items.AddRange(new object[] { 1, 3, 5, 7, 9 });
                        addThreads();
                        cbPARMemory.Items.AddRange(new object[] { "32KB" });
                        cbPARWordSize.Items.AddRange(new object[] { 8, 12, 16, 24, 32, 48, 64, 96, 128, 192, 256, 258 });
                        break;
                    }
                case "Deflate64":
                    {
                        clearAll();
                        cbPARLevel.Items.AddRange(new object[] { 1, 3, 5, 7, 9 });
                        addThreads();
                        cbPARMemory.Items.AddRange(new object[] { "64KB" });
                        cbPARWordSize.Items.AddRange(new object[] { 8, 12, 16, 24, 32, 48, 64, 96, 128, 192, 256, 257 });
                        break;
                    }
                #endregion
                //BSC
                case "BWT":
                    {
                        clearAll();
                        cbPARMemory.Items.AddRange(new object[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 384, 512, 768, 1024, 2047 });
                        break;
                    }

            }
            void clearAll()
            {
                cbPARLevel.Items.Clear();
                cbPARThreads.Items.Clear();
                cbPARWordSize.Items.Clear();
                cbPARMemory.Items.Clear();
            }
            void addThreads()
            {
                int totalThedas = specs.ThreadsCPU();
                for (int i = 1; i <= totalThedas; i++)
                    cbPARThreads.Items.Add(i);
            }
        }
        #endregion

        #endregion

        #region Drag and drop
        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                jobs.Add(new JobClass(jobs.Count + 1, file, "Queued", check.SizeOf(file), -1, "Waiting"));
            }
        }
        #endregion

        #region Extras
        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            lblState.Text = "State: BENCHMARK";
            Process zip7 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            zip7.StartInfo.WorkingDirectory = @".\Working Directory";

            zip7.StartInfo.UseShellExecute = true;
            zip7.StartInfo.FileName = "7za.exe";
            zip7.StartInfo.Arguments = "b";

            zip7.Start();
            zip7.WaitForExit();
            lblState.Text = "State: Inactive";
        }

        private void btnElevate_Click(object sender, EventArgs e)
        {
            try
            {
                startAdmin.ExecuteAsAdmin("Saratov.exe");
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("Failed to restart with administrator privilages.", "Error");
            }
        }

        private void lblManual_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            process.StartInfo.Arguments = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Manual.txt";
            process.Start();
        }
        #endregion

        #region Save and Load
        private void btnSaveJobs_Click(object sender, EventArgs e) { saveload.Save(jobs); }
        private void btnLoadJobs_Click(object sender, EventArgs e) { saveload.Load(); } //Not ready
        #endregion

        #region Clear All and Done
        private void btnClearAllJobs_Click(object sender, EventArgs e) { jobs = ClearJobs.All(jobs); }
        private void btnClearDoneJobs_Click(object sender, EventArgs e) { jobs = ClearJobs.Done(jobs); }
        #endregion

        #region Additional Controls
        private void lblACSort_Click(object sender, EventArgs e)
        {
            lblACSort.ForeColor = Color.Olive;
            var sortedJobs = new BindingList<JobClass>(jobs.OrderBy(x => x.SizeBefore).ToList());
            jobs = sortedJobs;
            dgvJobs.DataSource = null;
            dgvJobs.DataSource = jobs;
            GC.Collect();
            lblACSort.ForeColor = Color.Green;
        }
        private void lblACDeleteAfter_Click(object sender, EventArgs e)
        {
            if (lblACDeleteAfter.ForeColor == Color.Firebrick)
            { lblACDeleteAfter.ForeColor = Color.Green; }
            else { lblACDeleteAfter.ForeColor = Color.Firebrick; }
        }
        private void lblACSilent_Click(object sender, EventArgs e)
        {
            if (lblACSilent.ForeColor == Color.Firebrick)
            { lblACSilent.ForeColor = Color.Green; }
            else { lblACSilent.ForeColor = Color.Firebrick; }
        }
        #endregion

        private void btnTest_Click(object sender, EventArgs e)
        {
            //jobs.Add(new JobClass(1, "test", "test", 1.11, 1.22, "test"));
        }
    }
}
