
namespace Saratov
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblState = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblElevation = new System.Windows.Forms.Label();
            this.btnElevate = new System.Windows.Forms.Button();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.rbtnTest = new System.Windows.Forms.RadioButton();
            this.rbtnExtract = new System.Windows.Forms.RadioButton();
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.gbProgram = new System.Windows.Forms.GroupBox();
            this.rbtnBSC = new System.Windows.Forms.RadioButton();
            this.rbtnMCM = new System.Windows.Forms.RadioButton();
            this.rbtnFreeArc = new System.Windows.Forms.RadioButton();
            this.rbtn7z = new System.Windows.Forms.RadioButton();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.cbPARLevel = new System.Windows.Forms.ComboBox();
            this.cbPARFormat = new System.Windows.Forms.ComboBox();
            this.lblPARFormat = new System.Windows.Forms.Label();
            this.cbPARAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblPARalgorithm = new System.Windows.Forms.Label();
            this.lblPARMemory = new System.Windows.Forms.Label();
            this.cbPARMemory = new System.Windows.Forms.ComboBox();
            this.cbPARWordSize = new System.Windows.Forms.ComboBox();
            this.lblPARWordSize = new System.Windows.Forms.Label();
            this.tbPARThreads = new System.Windows.Forms.TextBox();
            this.lblPARThreads = new System.Windows.Forms.Label();
            this.lblPARLevel = new System.Windows.Forms.Label();
            this.lblAvailableMemory = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gbBehaviour = new System.Windows.Forms.GroupBox();
            this.rbtnBBrute = new System.Windows.Forms.RadioButton();
            this.rbtnBContinuous = new System.Windows.Forms.RadioButton();
            this.rbtnBRepack = new System.Windows.Forms.RadioButton();
            this.rbtnBNormal = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkbSilent = new System.Windows.Forms.CheckBox();
            this.tbArgs = new System.Windows.Forms.TextBox();
            this.chkbDeleteAfter = new System.Windows.Forms.CheckBox();
            this.chkbMultiple = new System.Windows.Forms.CheckBox();
            this.chkbNoValidation = new System.Windows.Forms.CheckBox();
            this.lblCoreThread = new System.Windows.Forms.Label();
            this.ofdOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerContinuous = new System.Windows.Forms.Timer(this.components);
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClearAllJobs = new System.Windows.Forms.Button();
            this.btnClearDoneJobs = new System.Windows.Forms.Button();
            this.timerMemory = new System.Windows.Forms.Timer(this.components);
            this.btnSaveJobs = new System.Windows.Forms.Button();
            this.btnLoadJobs = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.chkbImmediate = new System.Windows.Forms.CheckBox();
            this.lblManual = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.gbAction.SuspendLayout();
            this.gbProgram.SuspendLayout();
            this.gbParameters.SuspendLayout();
            this.gbBehaviour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(12, 17);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(76, 13);
            this.lblState.TabIndex = 1;
            this.lblState.Text = "State: Inactive";
            this.toolTip1.SetToolTip(this.lblState, "Displays current state of the program.\r\nInactive - Waiting for you to add new job" +
        "s and start them.\r\nActive - Going through tasks from the table below");
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(398, 136);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblElevation
            // 
            this.lblElevation.AutoSize = true;
            this.lblElevation.Location = new System.Drawing.Point(398, 17);
            this.lblElevation.Name = "lblElevation";
            this.lblElevation.Size = new System.Drawing.Size(57, 13);
            this.lblElevation.TabIndex = 5;
            this.lblElevation.Text = "Elevation: ";
            this.toolTip1.SetToolTip(this.lblElevation, "Displays what permissions the program has.");
            // 
            // btnElevate
            // 
            this.btnElevate.Location = new System.Drawing.Point(317, 12);
            this.btnElevate.Name = "btnElevate";
            this.btnElevate.Size = new System.Drawing.Size(75, 23);
            this.btnElevate.TabIndex = 6;
            this.btnElevate.Text = "Elevate";
            this.toolTip1.SetToolTip(this.btnElevate, "Will restart the program as administrator.\r\nYou will be prompted to allow this ex" +
        "ecution.");
            this.btnElevate.UseVisualStyleBackColor = true;
            this.btnElevate.Click += new System.EventHandler(this.btnElevate_Click);
            // 
            // btnBenchmark
            // 
            this.btnBenchmark.Location = new System.Drawing.Point(697, 194);
            this.btnBenchmark.Name = "btnBenchmark";
            this.btnBenchmark.Size = new System.Drawing.Size(75, 23);
            this.btnBenchmark.TabIndex = 7;
            this.btnBenchmark.Text = "Benchmark";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.rbtnTest);
            this.gbAction.Controls.Add(this.rbtnExtract);
            this.gbAction.Controls.Add(this.rbtnAdd);
            this.gbAction.Location = new System.Drawing.Point(12, 139);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(380, 43);
            this.gbAction.TabIndex = 9;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Actions For Archives";
            // 
            // rbtnTest
            // 
            this.rbtnTest.AutoSize = true;
            this.rbtnTest.Location = new System.Drawing.Point(133, 20);
            this.rbtnTest.Name = "rbtnTest";
            this.rbtnTest.Size = new System.Drawing.Size(46, 17);
            this.rbtnTest.TabIndex = 2;
            this.rbtnTest.Tag = "Test";
            this.rbtnTest.Text = "Test";
            this.rbtnTest.UseVisualStyleBackColor = true;
            this.rbtnTest.CheckedChanged += new System.EventHandler(this.rbtnTest_CheckedChanged);
            // 
            // rbtnExtract
            // 
            this.rbtnExtract.AutoSize = true;
            this.rbtnExtract.Location = new System.Drawing.Point(69, 20);
            this.rbtnExtract.Name = "rbtnExtract";
            this.rbtnExtract.Size = new System.Drawing.Size(58, 17);
            this.rbtnExtract.TabIndex = 1;
            this.rbtnExtract.Tag = "Extract";
            this.rbtnExtract.Text = "Extract";
            this.rbtnExtract.UseVisualStyleBackColor = true;
            this.rbtnExtract.CheckedChanged += new System.EventHandler(this.rbtnExtract_CheckedChanged);
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Location = new System.Drawing.Point(7, 20);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(56, 17);
            this.rbtnAdd.TabIndex = 0;
            this.rbtnAdd.Tag = "Add";
            this.rbtnAdd.Text = "Add to";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            this.rbtnAdd.CheckedChanged += new System.EventHandler(this.rbtnAdd_CheckedChanged);
            // 
            // gbProgram
            // 
            this.gbProgram.Controls.Add(this.rbtnBSC);
            this.gbProgram.Controls.Add(this.rbtnMCM);
            this.gbProgram.Controls.Add(this.rbtnFreeArc);
            this.gbProgram.Controls.Add(this.rbtn7z);
            this.gbProgram.Location = new System.Drawing.Point(12, 90);
            this.gbProgram.Name = "gbProgram";
            this.gbProgram.Size = new System.Drawing.Size(380, 43);
            this.gbProgram.TabIndex = 10;
            this.gbProgram.TabStop = false;
            this.gbProgram.Text = "Select A Program To Use";
            // 
            // rbtnBSC
            // 
            this.rbtnBSC.AutoSize = true;
            this.rbtnBSC.Location = new System.Drawing.Point(185, 19);
            this.rbtnBSC.Name = "rbtnBSC";
            this.rbtnBSC.Size = new System.Drawing.Size(46, 17);
            this.rbtnBSC.TabIndex = 3;
            this.rbtnBSC.Tag = "BSC";
            this.rbtnBSC.Text = "BSC";
            this.rbtnBSC.UseVisualStyleBackColor = true;
            this.rbtnBSC.CheckedChanged += new System.EventHandler(this.rbtnBSC_CheckedChanged);
            // 
            // rbtnMCM
            // 
            this.rbtnMCM.AutoSize = true;
            this.rbtnMCM.Enabled = false;
            this.rbtnMCM.Location = new System.Drawing.Point(129, 19);
            this.rbtnMCM.Name = "rbtnMCM";
            this.rbtnMCM.Size = new System.Drawing.Size(50, 17);
            this.rbtnMCM.TabIndex = 2;
            this.rbtnMCM.Tag = "MCM";
            this.rbtnMCM.Text = "MCM";
            this.rbtnMCM.UseVisualStyleBackColor = true;
            this.rbtnMCM.CheckedChanged += new System.EventHandler(this.rbtnMCM_CheckedChanged);
            // 
            // rbtnFreeArc
            // 
            this.rbtnFreeArc.AutoSize = true;
            this.rbtnFreeArc.Enabled = false;
            this.rbtnFreeArc.Location = new System.Drawing.Point(57, 19);
            this.rbtnFreeArc.Name = "rbtnFreeArc";
            this.rbtnFreeArc.Size = new System.Drawing.Size(68, 17);
            this.rbtnFreeArc.TabIndex = 1;
            this.rbtnFreeArc.Tag = "FreeARC";
            this.rbtnFreeArc.Text = "FreeARC";
            this.rbtnFreeArc.UseVisualStyleBackColor = true;
            this.rbtnFreeArc.CheckedChanged += new System.EventHandler(this.rbtnFreeArc_CheckedChanged);
            // 
            // rbtn7z
            // 
            this.rbtn7z.AutoSize = true;
            this.rbtn7z.Checked = true;
            this.rbtn7z.Location = new System.Drawing.Point(6, 19);
            this.rbtn7z.Name = "rbtn7z";
            this.rbtn7z.Size = new System.Drawing.Size(44, 17);
            this.rbtn7z.TabIndex = 0;
            this.rbtn7z.TabStop = true;
            this.rbtn7z.Tag = "7zip";
            this.rbtn7z.Text = "7zip";
            this.rbtn7z.UseVisualStyleBackColor = true;
            this.rbtn7z.CheckedChanged += new System.EventHandler(this.rbtn7z_CheckedChanged);
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.cbPARLevel);
            this.gbParameters.Controls.Add(this.cbPARFormat);
            this.gbParameters.Controls.Add(this.lblPARFormat);
            this.gbParameters.Controls.Add(this.cbPARAlgorithm);
            this.gbParameters.Controls.Add(this.lblPARalgorithm);
            this.gbParameters.Controls.Add(this.lblPARMemory);
            this.gbParameters.Controls.Add(this.cbPARMemory);
            this.gbParameters.Controls.Add(this.cbPARWordSize);
            this.gbParameters.Controls.Add(this.lblPARWordSize);
            this.gbParameters.Controls.Add(this.tbPARThreads);
            this.gbParameters.Controls.Add(this.lblPARThreads);
            this.gbParameters.Controls.Add(this.lblPARLevel);
            this.gbParameters.Location = new System.Drawing.Point(12, 188);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(380, 58);
            this.gbParameters.TabIndex = 11;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters/Options";
            // 
            // cbPARLevel
            // 
            this.cbPARLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPARLevel.Enabled = false;
            this.cbPARLevel.FormattingEnabled = true;
            this.cbPARLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "3",
            "5",
            "7",
            "9"});
            this.cbPARLevel.Location = new System.Drawing.Point(142, 32);
            this.cbPARLevel.Name = "cbPARLevel";
            this.cbPARLevel.Size = new System.Drawing.Size(54, 21);
            this.cbPARLevel.TabIndex = 24;
            // 
            // cbPARFormat
            // 
            this.cbPARFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPARFormat.Enabled = false;
            this.cbPARFormat.FormattingEnabled = true;
            this.cbPARFormat.Items.AddRange(new object[] {
            "7z",
            "bzip2",
            "gzip",
            "tar",
            "wim",
            "xz",
            "zip"});
            this.cbPARFormat.Location = new System.Drawing.Point(6, 32);
            this.cbPARFormat.Name = "cbPARFormat";
            this.cbPARFormat.Size = new System.Drawing.Size(63, 21);
            this.cbPARFormat.TabIndex = 23;
            // 
            // lblPARFormat
            // 
            this.lblPARFormat.AutoSize = true;
            this.lblPARFormat.Location = new System.Drawing.Point(6, 16);
            this.lblPARFormat.Name = "lblPARFormat";
            this.lblPARFormat.Size = new System.Drawing.Size(39, 13);
            this.lblPARFormat.TabIndex = 22;
            this.lblPARFormat.Text = "Format";
            this.toolTip1.SetToolTip(this.lblPARFormat, "Specify which algorithm to use for compressing.\r\nCan be left blank.\r\n");
            // 
            // cbPARAlgorithm
            // 
            this.cbPARAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPARAlgorithm.Enabled = false;
            this.cbPARAlgorithm.FormattingEnabled = true;
            this.cbPARAlgorithm.Items.AddRange(new object[] {
            "LZMA2",
            "LZMA",
            "PPMd",
            "BZip2"});
            this.cbPARAlgorithm.Location = new System.Drawing.Point(75, 32);
            this.cbPARAlgorithm.Name = "cbPARAlgorithm";
            this.cbPARAlgorithm.Size = new System.Drawing.Size(61, 21);
            this.cbPARAlgorithm.TabIndex = 21;
            // 
            // lblPARalgorithm
            // 
            this.lblPARalgorithm.AutoSize = true;
            this.lblPARalgorithm.Location = new System.Drawing.Point(72, 16);
            this.lblPARalgorithm.Name = "lblPARalgorithm";
            this.lblPARalgorithm.Size = new System.Drawing.Size(55, 13);
            this.lblPARalgorithm.TabIndex = 20;
            this.lblPARalgorithm.Text = "Algorithms";
            this.toolTip1.SetToolTip(this.lblPARalgorithm, "Specify which algorithm to use for compressing.\r\nCan be left blank.\r\n");
            // 
            // lblPARMemory
            // 
            this.lblPARMemory.AutoSize = true;
            this.lblPARMemory.Location = new System.Drawing.Point(305, 16);
            this.lblPARMemory.Name = "lblPARMemory";
            this.lblPARMemory.Size = new System.Drawing.Size(69, 13);
            this.lblPARMemory.TabIndex = 12;
            this.lblPARMemory.Text = "Memory (MB)";
            this.toolTip1.SetToolTip(this.lblPARMemory, "Specify how much memory the program can use.\r\nThis is NOT dictionary size.\r\nIf le" +
        "ft blank, an auto estimate will be used based on folder/file size.\r\n");
            // 
            // cbPARMemory
            // 
            this.cbPARMemory.Enabled = false;
            this.cbPARMemory.FormattingEnabled = true;
            this.cbPARMemory.Items.AddRange(new object[] {
            "32",
            "48",
            "64",
            "96",
            "128",
            "192",
            "256",
            "384",
            "512",
            "768",
            "1024",
            "1536",
            "2048",
            "3072",
            "3840"});
            this.cbPARMemory.Location = new System.Drawing.Point(308, 32);
            this.cbPARMemory.Name = "cbPARMemory";
            this.cbPARMemory.Size = new System.Drawing.Size(66, 21);
            this.cbPARMemory.TabIndex = 17;
            this.toolTip1.SetToolTip(this.cbPARMemory, "Specify how much memory the program can use.\r\nThis is NOT dictionary size.\r\nIf le" +
        "ft blank, an auto estimate will be used based on folder/file size.\r\n\r\n");
            // 
            // cbPARWordSize
            // 
            this.cbPARWordSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPARWordSize.Enabled = false;
            this.cbPARWordSize.FormattingEnabled = true;
            this.cbPARWordSize.Items.AddRange(new object[] {
            "8",
            "12",
            "16",
            "32",
            "48",
            "64",
            "96",
            "128",
            "192",
            "256",
            "273"});
            this.cbPARWordSize.Location = new System.Drawing.Point(251, 32);
            this.cbPARWordSize.Name = "cbPARWordSize";
            this.cbPARWordSize.Size = new System.Drawing.Size(51, 21);
            this.cbPARWordSize.TabIndex = 19;
            this.toolTip1.SetToolTip(this.cbPARWordSize, "Specify how much memory the program can use.\r\nThis is NOT dictionary size.\r\nIf le" +
        "ft blank, an auto estimate will be used based on folder/file size.\r\n\r\n");
            // 
            // lblPARWordSize
            // 
            this.lblPARWordSize.AutoSize = true;
            this.lblPARWordSize.Location = new System.Drawing.Point(248, 16);
            this.lblPARWordSize.Name = "lblPARWordSize";
            this.lblPARWordSize.Size = new System.Drawing.Size(54, 13);
            this.lblPARWordSize.TabIndex = 18;
            this.lblPARWordSize.Text = "Word size";
            this.toolTip1.SetToolTip(this.lblPARWordSize, "Specify the dictionarys\' word size.\r\nCan be blank.\r\n");
            // 
            // tbPARThreads
            // 
            this.tbPARThreads.Enabled = false;
            this.tbPARThreads.Location = new System.Drawing.Point(202, 32);
            this.tbPARThreads.Name = "tbPARThreads";
            this.tbPARThreads.Size = new System.Drawing.Size(43, 20);
            this.tbPARThreads.TabIndex = 16;
            this.toolTip1.SetToolTip(this.tbPARThreads, "Specify how many threds to use for compressing.\r\nLeave blank for an auto estimate" +
        ".");
            // 
            // lblPARThreads
            // 
            this.lblPARThreads.AutoSize = true;
            this.lblPARThreads.Location = new System.Drawing.Point(199, 16);
            this.lblPARThreads.Name = "lblPARThreads";
            this.lblPARThreads.Size = new System.Drawing.Size(46, 13);
            this.lblPARThreads.TabIndex = 15;
            this.lblPARThreads.Text = "Threads";
            this.toolTip1.SetToolTip(this.lblPARThreads, "Specify how many threads to use for compressing.\r\nLeave blank for an auto estimat" +
        "e.\r\n");
            // 
            // lblPARLevel
            // 
            this.lblPARLevel.AutoSize = true;
            this.lblPARLevel.Location = new System.Drawing.Point(139, 16);
            this.lblPARLevel.Name = "lblPARLevel";
            this.lblPARLevel.Size = new System.Drawing.Size(33, 13);
            this.lblPARLevel.TabIndex = 14;
            this.lblPARLevel.Text = "Level";
            this.toolTip1.SetToolTip(this.lblPARLevel, resources.GetString("lblPARLevel.ToolTip"));
            // 
            // lblAvailableMemory
            // 
            this.lblAvailableMemory.AutoSize = true;
            this.lblAvailableMemory.Location = new System.Drawing.Point(398, 41);
            this.lblAvailableMemory.Name = "lblAvailableMemory";
            this.lblAvailableMemory.Size = new System.Drawing.Size(93, 13);
            this.lblAvailableMemory.TabIndex = 12;
            this.lblAvailableMemory.Text = "Available Memory:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(697, 223);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test Button";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Tai Le", 15.25F);
            this.btnStartStop.Location = new System.Drawing.Point(398, 194);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 52);
            this.btnStartStop.TabIndex = 14;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbBehaviour
            // 
            this.gbBehaviour.AccessibleDescription = "";
            this.gbBehaviour.Controls.Add(this.rbtnBBrute);
            this.gbBehaviour.Controls.Add(this.rbtnBContinuous);
            this.gbBehaviour.Controls.Add(this.rbtnBRepack);
            this.gbBehaviour.Controls.Add(this.rbtnBNormal);
            this.gbBehaviour.Location = new System.Drawing.Point(12, 41);
            this.gbBehaviour.Name = "gbBehaviour";
            this.gbBehaviour.Size = new System.Drawing.Size(380, 43);
            this.gbBehaviour.TabIndex = 15;
            this.gbBehaviour.TabStop = false;
            this.gbBehaviour.Text = "Behaviour";
            this.toolTip1.SetToolTip(this.gbBehaviour, resources.GetString("gbBehaviour.ToolTip"));
            // 
            // rbtnBBrute
            // 
            this.rbtnBBrute.AccessibleDescription = "";
            this.rbtnBBrute.AutoSize = true;
            this.rbtnBBrute.Enabled = false;
            this.rbtnBBrute.Location = new System.Drawing.Point(223, 19);
            this.rbtnBBrute.Name = "rbtnBBrute";
            this.rbtnBBrute.Size = new System.Drawing.Size(80, 17);
            this.rbtnBBrute.TabIndex = 3;
            this.rbtnBBrute.Tag = "Brute";
            this.rbtnBBrute.Text = "Brute Force";
            this.rbtnBBrute.UseVisualStyleBackColor = true;
            // 
            // rbtnBContinuous
            // 
            this.rbtnBContinuous.AccessibleDescription = "";
            this.rbtnBContinuous.AutoSize = true;
            this.rbtnBContinuous.Enabled = false;
            this.rbtnBContinuous.Location = new System.Drawing.Point(139, 19);
            this.rbtnBContinuous.Name = "rbtnBContinuous";
            this.rbtnBContinuous.Size = new System.Drawing.Size(78, 17);
            this.rbtnBContinuous.TabIndex = 2;
            this.rbtnBContinuous.Tag = "Continuous";
            this.rbtnBContinuous.Text = "Continuous";
            this.rbtnBContinuous.UseVisualStyleBackColor = true;
            // 
            // rbtnBRepack
            // 
            this.rbtnBRepack.AutoSize = true;
            this.rbtnBRepack.Enabled = false;
            this.rbtnBRepack.Location = new System.Drawing.Point(70, 19);
            this.rbtnBRepack.Name = "rbtnBRepack";
            this.rbtnBRepack.Size = new System.Drawing.Size(63, 17);
            this.rbtnBRepack.TabIndex = 1;
            this.rbtnBRepack.Tag = "Repack";
            this.rbtnBRepack.Text = "Repack";
            this.rbtnBRepack.UseVisualStyleBackColor = true;
            // 
            // rbtnBNormal
            // 
            this.rbtnBNormal.AutoSize = true;
            this.rbtnBNormal.Checked = true;
            this.rbtnBNormal.Location = new System.Drawing.Point(6, 19);
            this.rbtnBNormal.Name = "rbtnBNormal";
            this.rbtnBNormal.Size = new System.Drawing.Size(58, 17);
            this.rbtnBNormal.TabIndex = 0;
            this.rbtnBNormal.TabStop = true;
            this.rbtnBNormal.Tag = "Normal";
            this.rbtnBNormal.Text = "Normal";
            this.rbtnBNormal.UseVisualStyleBackColor = true;
            // 
            // chkbSilent
            // 
            this.chkbSilent.AutoSize = true;
            this.chkbSilent.Location = new System.Drawing.Point(560, 140);
            this.chkbSilent.Name = "chkbSilent";
            this.chkbSilent.Size = new System.Drawing.Size(52, 17);
            this.chkbSilent.TabIndex = 23;
            this.chkbSilent.Text = "Silent";
            this.toolTip1.SetToolTip(this.chkbSilent, "No Console Window");
            this.chkbSilent.UseVisualStyleBackColor = true;
            // 
            // tbArgs
            // 
            this.tbArgs.Location = new System.Drawing.Point(398, 81);
            this.tbArgs.Multiline = true;
            this.tbArgs.Name = "tbArgs";
            this.tbArgs.Size = new System.Drawing.Size(374, 49);
            this.tbArgs.TabIndex = 25;
            this.tbArgs.Text = "Generated commands will show up here. For debug!";
            this.toolTip1.SetToolTip(this.tbArgs, "For Da Debug Purposes");
            // 
            // chkbDeleteAfter
            // 
            this.chkbDeleteAfter.AutoSize = true;
            this.chkbDeleteAfter.Location = new System.Drawing.Point(690, 140);
            this.chkbDeleteAfter.Name = "chkbDeleteAfter";
            this.chkbDeleteAfter.Size = new System.Drawing.Size(82, 17);
            this.chkbDeleteAfter.TabIndex = 26;
            this.chkbDeleteAfter.Text = "Delete After";
            this.toolTip1.SetToolTip(this.chkbDeleteAfter, "Will delete the orignal files after completing the task.\r\nWill run a test on the " +
        "archive before it deletes anything.\r\nDO NOT RELY ON THIS!");
            this.chkbDeleteAfter.UseVisualStyleBackColor = true;
            // 
            // chkbMultiple
            // 
            this.chkbMultiple.AutoSize = true;
            this.chkbMultiple.Enabled = false;
            this.chkbMultiple.Location = new System.Drawing.Point(560, 198);
            this.chkbMultiple.Name = "chkbMultiple";
            this.chkbMultiple.Size = new System.Drawing.Size(75, 17);
            this.chkbMultiple.TabIndex = 27;
            this.chkbMultiple.Text = "Run Many";
            this.toolTip1.SetToolTip(this.chkbMultiple, "Allow the program to start as many tasks as it wants.");
            this.chkbMultiple.UseVisualStyleBackColor = true;
            // 
            // chkbNoValidation
            // 
            this.chkbNoValidation.AutoSize = true;
            this.chkbNoValidation.Location = new System.Drawing.Point(560, 227);
            this.chkbNoValidation.Name = "chkbNoValidation";
            this.chkbNoValidation.Size = new System.Drawing.Size(89, 17);
            this.chkbNoValidation.TabIndex = 28;
            this.chkbNoValidation.Text = "No Validation";
            this.toolTip1.SetToolTip(this.chkbNoValidation, "Will skip validation of the parameters.");
            this.chkbNoValidation.UseVisualStyleBackColor = true;
            // 
            // lblCoreThread
            // 
            this.lblCoreThread.AutoSize = true;
            this.lblCoreThread.Location = new System.Drawing.Point(398, 65);
            this.lblCoreThread.Name = "lblCoreThread";
            this.lblCoreThread.Size = new System.Drawing.Size(87, 13);
            this.lblCoreThread.TabIndex = 16;
            this.lblCoreThread.Text = "Cores / Threads:";
            // 
            // ofdOpenDialog
            // 
            this.ofdOpenDialog.FileName = "Open...";
            this.ofdOpenDialog.InitialDirectory = "C:\\";
            // 
            // dgvJobs
            // 
            this.dgvJobs.AllowUserToOrderColumns = true;
            this.dgvJobs.AutoGenerateColumns = false;
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Address,
            this.dataGridViewTextBoxColumn3,
            this.Progress,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvJobs.DataSource = this.jobClassBindingSource;
            this.dgvJobs.Location = new System.Drawing.Point(12, 252);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.Size = new System.Drawing.Size(760, 297);
            this.dgvJobs.TabIndex = 17;
            this.dgvJobs.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobs_RowEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Width = 320;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "State";
            this.dataGridViewTextBoxColumn3.HeaderText = "State";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // Progress
            // 
            this.Progress.HeaderText = "Progress";
            this.Progress.Name = "Progress";
            this.Progress.Visible = false;
            this.Progress.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SizeBefore";
            this.dataGridViewTextBoxColumn4.HeaderText = "Size Before (MB)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SizeAfter";
            this.dataGridViewTextBoxColumn5.HeaderText = "Size After (MB)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // jobClassBindingSource
            // 
            this.jobClassBindingSource.DataSource = typeof(Saratov.JobClass);
            // 
            // btnClearAllJobs
            // 
            this.btnClearAllJobs.Location = new System.Drawing.Point(479, 223);
            this.btnClearAllJobs.Name = "btnClearAllJobs";
            this.btnClearAllJobs.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllJobs.TabIndex = 18;
            this.btnClearAllJobs.Text = "Clear All";
            this.btnClearAllJobs.UseVisualStyleBackColor = true;
            this.btnClearAllJobs.Click += new System.EventHandler(this.btnClearAllJobs_Click);
            // 
            // btnClearDoneJobs
            // 
            this.btnClearDoneJobs.Location = new System.Drawing.Point(479, 194);
            this.btnClearDoneJobs.Name = "btnClearDoneJobs";
            this.btnClearDoneJobs.Size = new System.Drawing.Size(75, 23);
            this.btnClearDoneJobs.TabIndex = 19;
            this.btnClearDoneJobs.Text = "Clear Done";
            this.btnClearDoneJobs.UseVisualStyleBackColor = true;
            this.btnClearDoneJobs.Click += new System.EventHandler(this.btnClearDoneJobs_Click);
            // 
            // btnSaveJobs
            // 
            this.btnSaveJobs.Location = new System.Drawing.Point(479, 165);
            this.btnSaveJobs.Name = "btnSaveJobs";
            this.btnSaveJobs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveJobs.TabIndex = 20;
            this.btnSaveJobs.Text = "Save";
            this.btnSaveJobs.UseVisualStyleBackColor = true;
            this.btnSaveJobs.Click += new System.EventHandler(this.btnSaveJobs_Click);
            // 
            // btnLoadJobs
            // 
            this.btnLoadJobs.Location = new System.Drawing.Point(479, 136);
            this.btnLoadJobs.Name = "btnLoadJobs";
            this.btnLoadJobs.Size = new System.Drawing.Size(75, 23);
            this.btnLoadJobs.TabIndex = 21;
            this.btnLoadJobs.Text = "Load";
            this.btnLoadJobs.UseVisualStyleBackColor = true;
            this.btnLoadJobs.Click += new System.EventHandler(this.btnLoadJobs_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(398, 165);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolder.TabIndex = 22;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // chkbImmediate
            // 
            this.chkbImmediate.AutoSize = true;
            this.chkbImmediate.Enabled = false;
            this.chkbImmediate.Location = new System.Drawing.Point(560, 169);
            this.chkbImmediate.Name = "chkbImmediate";
            this.chkbImmediate.Size = new System.Drawing.Size(74, 17);
            this.chkbImmediate.TabIndex = 24;
            this.chkbImmediate.Text = "Immediate";
            this.chkbImmediate.UseVisualStyleBackColor = true;
            // 
            // lblManual
            // 
            this.lblManual.AutoSize = true;
            this.lblManual.Location = new System.Drawing.Point(686, 17);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(86, 13);
            this.lblManual.TabIndex = 24;
            this.lblManual.Text = "Click For Manual";
            this.lblManual.Click += new System.EventHandler(this.lblManual_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.chkbNoValidation);
            this.Controls.Add(this.chkbMultiple);
            this.Controls.Add(this.chkbDeleteAfter);
            this.Controls.Add(this.lblManual);
            this.Controls.Add(this.tbArgs);
            this.Controls.Add(this.chkbImmediate);
            this.Controls.Add(this.chkbSilent);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnLoadJobs);
            this.Controls.Add(this.btnSaveJobs);
            this.Controls.Add(this.btnClearDoneJobs);
            this.Controls.Add(this.btnClearAllJobs);
            this.Controls.Add(this.dgvJobs);
            this.Controls.Add(this.lblCoreThread);
            this.Controls.Add(this.gbBehaviour);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblAvailableMemory);
            this.Controls.Add(this.gbParameters);
            this.Controls.Add(this.gbProgram);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.btnBenchmark);
            this.Controls.Add(this.btnElevate);
            this.Controls.Add(this.lblElevation);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lblState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Saratov";
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            this.gbProgram.ResumeLayout(false);
            this.gbProgram.PerformLayout();
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            this.gbBehaviour.ResumeLayout(false);
            this.gbBehaviour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobClassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label lblElevation;
        private System.Windows.Forms.Button btnElevate;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.RadioButton rbtnExtract;
        private System.Windows.Forms.RadioButton rbtnTest;
        private System.Windows.Forms.GroupBox gbProgram;
        private System.Windows.Forms.RadioButton rbtn7z;
        private System.Windows.Forms.RadioButton rbtnMCM;
        private System.Windows.Forms.RadioButton rbtnFreeArc;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.Label lblPARMemory;
        private System.Windows.Forms.Label lblAvailableMemory;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblPARLevel;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gbBehaviour;
        private System.Windows.Forms.RadioButton rbtnBContinuous;
        private System.Windows.Forms.RadioButton rbtnBRepack;
        private System.Windows.Forms.RadioButton rbtnBNormal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblCoreThread;
        private System.Windows.Forms.OpenFileDialog ofdOpenDialog;
        private System.Windows.Forms.Timer timerContinuous;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeBeforeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeAfterDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource jobClassBindingSource;
        private System.Windows.Forms.Button btnClearAllJobs;
        private System.Windows.Forms.Button btnClearDoneJobs;
        private System.Windows.Forms.Timer timerMemory;
        private System.Windows.Forms.Button btnSaveJobs;
        private System.Windows.Forms.Button btnLoadJobs;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label lblPARThreads;
        private System.Windows.Forms.CheckBox chkbSilent;
        private System.Windows.Forms.CheckBox chkbImmediate;
        internal System.Windows.Forms.TextBox tbPARThreads;
        internal System.Windows.Forms.ComboBox cbPARMemory;
        internal System.Windows.Forms.DataGridView dgvJobs;
        internal System.Windows.Forms.ComboBox cbPARWordSize;
        private System.Windows.Forms.Label lblPARWordSize;
        internal System.Windows.Forms.ComboBox cbPARAlgorithm;
        private System.Windows.Forms.Label lblPARalgorithm;
        private System.Windows.Forms.TextBox tbArgs;
        private System.Windows.Forms.RadioButton rbtnBSC;
        private System.Windows.Forms.RadioButton rbtnBBrute;
        internal System.Windows.Forms.ComboBox cbPARFormat;
        private System.Windows.Forms.Label lblPARFormat;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.CheckBox chkbDeleteAfter;
        private System.Windows.Forms.CheckBox chkbMultiple;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckBox chkbNoValidation;
        internal System.Windows.Forms.ComboBox cbPARLevel;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}

