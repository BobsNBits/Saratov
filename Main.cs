using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Saratov
{
    public partial class Main : Form
    {
        #region Declarations
        public BindingList<JobClass> jobs = new BindingList<JobClass>();
        public List<ParameterClass> parameters = new List<ParameterClass>();

        Checks check = new Checks();
        Specs specs = new Specs();
        StartAdmin startAdmin = new StartAdmin();
        CommandGen commandgen = new CommandGen();

        OpenFileDialog fileDialog = new OpenFileDialog();
        FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        //BackgroundWorker bgWorker = new BackgroundWorker();
        #endregion
        public Main() { InitializeComponent(); }

        private void Main_Load(object sender, EventArgs e)
        {
            lblElevation.Text = check.IsAdministrator();
            dgvJobs.DataSource = jobs;
            lblCoreThread.Text = "Cores / Threads: " + specs.coresCPU() + "C / " + specs.threadsCPU().ToString() + "T";
            lblAvailableMemory.Text = "Available Memory: " + specs.availableRAM() + "MB / " + specs.totalRAM() + "MB";
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
                lblState.Text = "State: Active";
                btnStartStop.BackColor = Color.Red;
                btnStartStop.Text = "Stop";
                bgWorker.RunWorkerAsync();
            }
        }

        private void dgvJobs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Update UI Parameter boxes based on selected task
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        #region Background Worker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int program = 0;
            int action = 0;

            var selectedProgram = gbProgram.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var selectedAction = gbAction.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (selectedProgram.Tag)
            {
                case "7zip": { program = 1; break; }
                case "FreeARC": { program = 2; break; }
                case "MCM": { program = 3; break; }
                case "BSC": { program = 4; break; }
            }
            try
            {
                switch (selectedAction.Tag)
                {
                    case "Add": { action = 1; break; }
                    case "Extract": { action = 2; break; }
                    case "Test": { action = 3; break; }
                    default: { MessageBox.Show("Please select an action.", "Info"); break; }
                }
            }
            catch
            {
                MessageBox.Show("Please select an action.", "Error");
                return;
            }

            this.Invoke(new MethodInvoker(delegate ()
            {
                ValidateInput(program, action);
            }));

            Worker worker = new Worker();
            int currentJob = 0;

            while (currentJob < jobs.Count() && bgWorker.CancellationPending == false)
            {
                if (jobs[currentJob].State == "Queued")
                {
                    jobs[currentJob].State = "Working...";

                    string args = null;

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        args = commandgen.Prepare(program, action, cbPARAlgorithm.Text,
                                                                int.Parse(cbPARLevel.Text),
                                                                int.Parse(cbPARMemory.Text),
                                                                int.Parse(cbPARWordSize.Text),
                                                                int.Parse(tbPARThreads.Text),
                                                                cbPARFormat.Text,
                                                                jobs[currentJob],
                                                                chkbDeleteAfter.Checked);
                    }));

                    Action delegateAction = () => tbArgs.Text = args;
                    tbArgs.Invoke(delegateAction);

                    worker.Start(jobs[currentJob], args, chkbSilent.Checked, program);

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        jobs[currentJob].SizeAfter = check.Size(Path.ChangeExtension(jobs[currentJob].Address, cbPARFormat.Text));
                        jobs[currentJob].State = "DONE";
                        dgvJobs.Refresh();
                    }));
                    currentJob++;
                }
                else { currentJob++; }
            };
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblState.Text = "State: Inactive";
            btnStartStop.BackColor = Color.LimeGreen;
            btnStartStop.Text = "Start";
        }
        #endregion

        #region User Input Validation
        public void ValidateInput(int program, int action)
        {
            if (chkbNoValidation.Checked == false)
            {
                int availableThreads = (int)specs.threadsCPU();
                int availableRAM = (int)specs.availableRAM();
                int totalVRAM = (int)specs.totalVRAM();

                if (tbPARThreads.Text != "" && (int.Parse(tbPARThreads.Text) > availableThreads || int.Parse(tbPARThreads.Text) < 1))
                {
                    MessageBox.Show("You don't have that many threads.", "Info");
                    tbPARThreads.Text = availableThreads.ToString();
                }

                //Per Program Memory and Thread validation
                switch (program)
                {
                    case 1: //7zip
                        {
                            int[] memoryTemplate = { 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024, 1536, 2048, 3072, 3840 };
                            if (cbPARMemory.Text == "")
                            {
                                //MessageBox.Show("Empty Memory Box", "Debug");
                                int memTindex = 0;
                                if (tbPARThreads.Text == "")
                                {
                                    //MessageBox.Show("Empty Threads Box", "Debug");
                                    tbPARThreads.Text = availableThreads.ToString();
                                    //MessageBox.Show("Set Threads Box to " + availableThreads.ToString(), "Debug");

                                    while ((int.Parse(tbPARThreads.Text) * memoryTemplate[memTindex]) * 5.5 < availableRAM * 0.8)
                                    {
                                        memTindex++;
                                    };
                                    cbPARMemory.Text = memoryTemplate[memTindex].ToString();
                                    //MessageBox.Show("Set Memory Box to " + memoryTemplate[memTindex].ToString(), "Test");
                                    //MessageBox.Show((int.Parse(tbThreads.Text) * memoryTemplate[memTindex] * 6).ToString(), "Debug");

                                }
                                else
                                {
                                    //MessageBox.Show("Filled Thread Box", "Debug");
                                    while ((int.Parse(tbPARThreads.Text) * memoryTemplate[memTindex]) * 5.5 <= availableRAM * 0.8)
                                    {
                                        memTindex++;
                                    };
                                    cbPARMemory.Text = memoryTemplate[memTindex].ToString();
                                    //MessageBox.Show("Set Memory Box to " + memoryTemplate[memTindex].ToString(), "Debug");
                                }
                            }
                            else
                            {
                                if (tbPARThreads.Text == "")
                                {
                                    //MessageBox.Show("Empty Threads Box", "Debug");
                                    tbPARThreads.Text = availableThreads.ToString();
                                    //MessageBox.Show("Set Threads Box to " + availableThreads.ToString(), "Debug");
                                    while (int.Parse(tbPARThreads.Text) * int.Parse(cbPARMemory.Text) * 5.5 > availableRAM)
                                    {
                                        if (int.Parse(tbPARThreads.Text) > 0)
                                        {
                                            tbPARThreads.Text = (int.Parse(tbPARThreads.Text) - 1).ToString();
                                        }
                                    };
                                    if (int.Parse(tbPARThreads.Text) == 1)
                                    {
                                        MessageBox.Show("Insufficient RAM for the dictionary!", "Error");
                                        tbPARThreads.Text = "";
                                        cbPARMemory.Text = "";
                                    }
                                }
                                else
                                {
                                    if (int.Parse(tbPARThreads.Text) * int.Parse(cbPARMemory.Text) * 5.5 > availableRAM)
                                    {
                                        MessageBox.Show("Insufficient RAM for the dictionary!", "Error");
                                        tbPARThreads.Text = "";
                                        cbPARMemory.Text = "";
                                    }
                                }
                            }
                            break;
                        }
                    case 4: //BSC
                        {
                            if (cbPARMemory.Text == "")
                            {
                                int[] memoryTemplate = { 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024, 1536, 2048, 3072, 3840 };
                                int memTindex = 0;
                                while ((memoryTemplate[memTindex] * 20) <= totalVRAM * 0.9)
                                {

                                    memTindex++;
                                };
                                cbPARMemory.Text = memoryTemplate[memTindex].ToString();
                            }
                            tbPARThreads.Text = "1";
                            break;
                            //GPU memory usage for NVIDIA CUDA technology is different from CPU memory usage
                            //and can be estimated as 20 x block size for ST, 21 x block size for forward BWT
                            //and 7 x block size for inverse BWT.
                        }
                }
                //Per Program Level validation
                switch (program)
                {
                    case 1:
                        {
                            if (cbPARLevel.Text == "" || int.Parse(cbPARLevel.Text) % 2 == 0 || (int.Parse(cbPARLevel.Text) < 0 || int.Parse(cbPARLevel.Text) > 9))
                                cbPARLevel.Text = "9";
                            break;
                        }
                    case 4:
                        {
                            cbPARLevel.Text = "-1";
                            break;
                        }
                }
            }

            //Empty Parameter Fill
            if (cbPARAlgorithm.Text == "") { cbPARAlgorithm.SelectedIndex = 1; }
            if (cbPARFormat.Text == "") { cbPARFormat.SelectedIndex = 0; }
            if (cbPARLevel.Text == "") { cbPARLevel.SelectedIndex = cbPARLevel.Items.Count - 1; }
            if (cbPARWordSize.Text == "") { cbPARWordSize.SelectedIndex = 5; }
            if (cbPARMemory.Text == "") { cbPARMemory.SelectedIndex = 2; }
            if (tbPARThreads.Text == "") { tbPARThreads.Text = "2"; }
        }
        #endregion

        #region Per action parameter enabling
        //TODO: Switch to adjust based on the program
        private void rbtnTest_CheckedChanged(object sender, EventArgs e)
        {
            cbPARFormat.Enabled = false;
            cbPARMemory.Enabled = false;
            cbPARLevel.Enabled = false;
            tbPARThreads.Enabled = false;
            cbPARWordSize.Enabled = false;
            cbPARAlgorithm.Enabled = false;
        }

        private void rbtnExtract_CheckedChanged(object sender, EventArgs e)
        {
            cbPARFormat.Enabled = false;
            cbPARMemory.Enabled = false;
            cbPARLevel.Enabled = false;
            tbPARThreads.Enabled = false;
            cbPARWordSize.Enabled = false;
            cbPARAlgorithm.Enabled = false;
        }

        private void rbtnAdd_CheckedChanged(object sender, EventArgs e)
        {
            int program = 0;
            var selectedProgram = gbProgram.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked);

            switch (selectedProgram.Tag)
            {
                case "7zip":
                    {
                        program = 1;
                        break;
                    }
                case "FreeARC":
                    {
                        program = 2;
                        break;
                    }
                case "MCM":
                    {
                        program = 3;
                        break;
                    }
                case "BSC":
                    {
                        program = 4;
                        break;
                    }
            }
            switch (program)
            {
                case 1:
                    {
                        cbPARFormat.Enabled = true;
                        cbPARMemory.Enabled = true;
                        cbPARLevel.Enabled = true;
                        tbPARThreads.Enabled = true;
                        cbPARWordSize.Enabled = true;
                        cbPARAlgorithm.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        cbPARFormat.Enabled = true;
                        cbPARMemory.Enabled = true;
                        cbPARLevel.Enabled = true;
                        tbPARThreads.Enabled = false;
                        cbPARWordSize.Enabled = false;
                        cbPARAlgorithm.Enabled = true;
                        break;
                    }

            }
        }
        #endregion

        #region Per program parameter section adjustment and action enabling
        private void rbtn7z_CheckedChanged(object sender, EventArgs e)
        {
            rbtnTest.Enabled = true;
            cbPARFormat.Items.Clear();
            cbPARFormat.Items.Add("7z");
            cbPARFormat.Items.Add("bzip2");
            cbPARFormat.Items.Add("gzip");
            cbPARFormat.Items.Add("tar");
            cbPARFormat.Items.Add("wim");
            cbPARFormat.Items.Add("xz");
            cbPARFormat.Items.Add("zip");

            cbPARAlgorithm.Items.Clear();
            cbPARAlgorithm.Items.Add("LZMA2");
            cbPARAlgorithm.Items.Add("LZMA");
            cbPARAlgorithm.Items.Add("PPMd");
            cbPARAlgorithm.Items.Add("BZip2");

            cbPARLevel.Items.Clear();
            cbPARLevel.Items.Add("0");
            cbPARLevel.Items.Add("1");
            cbPARLevel.Items.Add("3");
            cbPARLevel.Items.Add("5");
            cbPARLevel.Items.Add("7");
            cbPARLevel.Items.Add("9");
        }

        private void rbtnFreeArc_CheckedChanged(object sender, EventArgs e) { }

        private void rbtnMCM_CheckedChanged(object sender, EventArgs e) { }

        private void rbtnBSC_CheckedChanged(object sender, EventArgs e)
        {
            rbtnTest.Enabled = false;
            cbPARFormat.Items.Clear();
            cbPARFormat.Items.Add("bsc");

            cbPARAlgorithm.Items.Clear();
            cbPARAlgorithm.Items.Add("0");
            cbPARAlgorithm.Items.Add("3");
            cbPARAlgorithm.Items.Add("4");
            cbPARAlgorithm.Items.Add("5");
            cbPARAlgorithm.Items.Add("6");
            cbPARAlgorithm.Items.Add("7");
            cbPARAlgorithm.Items.Add("8");

            cbPARLevel.Items.Clear();
            cbPARLevel.Items.Add("-1");
        }
        #endregion

        #region Save and Load
        private void btnSaveJobs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text|*.txt|All|*.*", ValidateNames = true, Multiselect = false };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(ofd.FileName);
                int listLenght = jobs.Count();

                foreach (var job in jobs)
                {
                    int i = jobs.Count - listLenght;
                    sw.WriteLine
                        (
                        jobs[i].ID + " " +
                        jobs[i].State + " " +
                        jobs[i].Address + " " +
                        jobs[i].SizeBefore + " " +
                        jobs[i].SizeAfter + " "
                        );
                    listLenght -= 1;
                }
                sw.Close();
            }
        }

        private void btnLoadJobs_Click(object sender, EventArgs e)
        {
            //TODO: Loading... Please wait [japanese letters here]
        }
        #endregion

        #region Clear All and Done
        private void btnClearAllJobs_Click(object sender, EventArgs e)
        {

            var mesBoxResult = MessageBox.Show("You are about to clear ALL jobs in the list \nProceed?", "Confirmation",
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            switch (mesBoxResult)
            {
                case DialogResult.OK:
                    {
                        jobs.Clear();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void btnClearDoneJobs_Click(object sender, EventArgs e)
        {
            var mesBoxResult = MessageBox.Show("Remove completed jobs?", "Confirmation",
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            switch (mesBoxResult)
            {
                case DialogResult.OK:
                    {
                        int listLenght = jobs.Count;
                        do
                        {
                            int i = jobs.Count - listLenght;
                            if (jobs[i].State == "DONE")
                            {
                                jobs.Remove(jobs[i]);
                            }
                            listLenght -= 1;
                        }
                        while (listLenght != 0);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
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
                if (check.DirExists(file) == -1)
                {
                    break;
                }
                else
                {
                    jobs.Add(new JobClass(jobs.Count + 1, file, "Queued", check.Size(file), -1, "Waiting"));
                    //dgvJobs.Name = "";
                }
                DirectoryInfo addressDI = new DirectoryInfo(file);
            }
        }
        #endregion

        #region Open Folder/Browse to buttons
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (check.DirExists(fileDialog.FileName) != -1)
                {
                    var filepath = fileDialog.FileName;
                    jobs.Add(new JobClass(jobs.Count + 1, filepath, "Queued", check.Size(filepath), -1, "Waiting"));
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                if (check.DirExists(folderDialog.SelectedPath) != -1)
                {
                    var folderpath = folderDialog.SelectedPath;
                    jobs.Add(new JobClass(jobs.Count + 1, folderpath, "Queued", check.Size(folderpath), -1, "Waiting"));
                }
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
    }
}