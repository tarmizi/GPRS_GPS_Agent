namespace GPSAgent.Components.Form
{
	partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.CtrlDeviceGroup = new System.Windows.Forms.GroupBox();
            this.CtrlDeviceEditButton = new System.Windows.Forms.Button();
            this.CtrlDeviceList = new System.Windows.Forms.ComboBox();
            this.CtrlDeviceLabel = new System.Windows.Forms.Label();
            this.CtrlServerGroup = new System.Windows.Forms.GroupBox();
            this.CtrlClientsLabel = new System.Windows.Forms.Label();
            this.CtrlServerStatusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CtrlClientsText = new System.Windows.Forms.Label();
            this.CtrlServerStartButton = new System.Windows.Forms.Button();
            this.CtrlServerStatusText = new System.Windows.Forms.Label();
            this.CtrlLogListView = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTracfficSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDeviceCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoFenceTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriberAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geofencesMonitoringCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDB = new System.Windows.Forms.Label();
            this.labelDBserver = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDeviceCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCountedPacket = new System.Windows.Forms.Label();
            this.labelDeviceConnected = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.labelProgramStarted = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelSMSAgentStatus = new System.Windows.Forms.Label();
            this.labellogin = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBoxGPSpacket = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CtrlDeviceGroup.SuspendLayout();
            this.CtrlServerGroup.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlDeviceGroup
            // 
            this.CtrlDeviceGroup.Controls.Add(this.CtrlDeviceEditButton);
            this.CtrlDeviceGroup.Controls.Add(this.CtrlDeviceList);
            this.CtrlDeviceGroup.Controls.Add(this.CtrlDeviceLabel);
            this.CtrlDeviceGroup.Location = new System.Drawing.Point(13, 150);
            this.CtrlDeviceGroup.Name = "CtrlDeviceGroup";
            this.CtrlDeviceGroup.Size = new System.Drawing.Size(240, 77);
            this.CtrlDeviceGroup.TabIndex = 0;
            this.CtrlDeviceGroup.TabStop = false;
            this.CtrlDeviceGroup.Text = "Device";
            // 
            // CtrlDeviceEditButton
            // 
            this.CtrlDeviceEditButton.Enabled = false;
            this.CtrlDeviceEditButton.Location = new System.Drawing.Point(169, 48);
            this.CtrlDeviceEditButton.Name = "CtrlDeviceEditButton";
            this.CtrlDeviceEditButton.Size = new System.Drawing.Size(55, 23);
            this.CtrlDeviceEditButton.TabIndex = 4;
            this.CtrlDeviceEditButton.Text = "Edit";
            this.CtrlDeviceEditButton.UseVisualStyleBackColor = true;
            this.CtrlDeviceEditButton.Click += new System.EventHandler(this.CtrlDeviceEditButton_Click);
            // 
            // CtrlDeviceList
            // 
            this.CtrlDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtrlDeviceList.FormattingEnabled = true;
            this.CtrlDeviceList.Location = new System.Drawing.Point(60, 21);
            this.CtrlDeviceList.Name = "CtrlDeviceList";
            this.CtrlDeviceList.Size = new System.Drawing.Size(165, 21);
            this.CtrlDeviceList.TabIndex = 3;
            this.CtrlDeviceList.SelectedIndexChanged += new System.EventHandler(this.CtrlDeviceList_SelectedIndexChanged);
            // 
            // CtrlDeviceLabel
            // 
            this.CtrlDeviceLabel.AutoSize = true;
            this.CtrlDeviceLabel.Location = new System.Drawing.Point(17, 24);
            this.CtrlDeviceLabel.Name = "CtrlDeviceLabel";
            this.CtrlDeviceLabel.Size = new System.Drawing.Size(42, 13);
            this.CtrlDeviceLabel.TabIndex = 2;
            this.CtrlDeviceLabel.Text = "Name :";
            // 
            // CtrlServerGroup
            // 
            this.CtrlServerGroup.Controls.Add(this.CtrlClientsLabel);
            this.CtrlServerGroup.Controls.Add(this.CtrlServerStatusLabel);
            this.CtrlServerGroup.Controls.Add(this.button1);
            this.CtrlServerGroup.Location = new System.Drawing.Point(259, 151);
            this.CtrlServerGroup.Name = "CtrlServerGroup";
            this.CtrlServerGroup.Size = new System.Drawing.Size(240, 77);
            this.CtrlServerGroup.TabIndex = 1;
            this.CtrlServerGroup.TabStop = false;
            this.CtrlServerGroup.Text = "Server";
            this.CtrlServerGroup.Enter += new System.EventHandler(this.CtrlServerGroup_Enter);
            // 
            // CtrlClientsLabel
            // 
            this.CtrlClientsLabel.AutoSize = true;
            this.CtrlClientsLabel.Location = new System.Drawing.Point(6, 41);
            this.CtrlClientsLabel.Name = "CtrlClientsLabel";
            this.CtrlClientsLabel.Size = new System.Drawing.Size(107, 13);
            this.CtrlClientsLabel.TabIndex = 3;
            this.CtrlClientsLabel.Text = "Clients Connected :";
            this.CtrlClientsLabel.Visible = false;
            // 
            // CtrlServerStatusLabel
            // 
            this.CtrlServerStatusLabel.AutoSize = true;
            this.CtrlServerStatusLabel.Location = new System.Drawing.Point(7, 24);
            this.CtrlServerStatusLabel.Name = "CtrlServerStatusLabel";
            this.CtrlServerStatusLabel.Size = new System.Drawing.Size(45, 13);
            this.CtrlServerStatusLabel.TabIndex = 0;
            this.CtrlServerStatusLabel.Text = "Status :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CtrlClientsText
            // 
            this.CtrlClientsText.AutoSize = true;
            this.CtrlClientsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlClientsText.ForeColor = System.Drawing.Color.White;
            this.CtrlClientsText.Location = new System.Drawing.Point(422, 0);
            this.CtrlClientsText.Name = "CtrlClientsText";
            this.CtrlClientsText.Size = new System.Drawing.Size(15, 15);
            this.CtrlClientsText.TabIndex = 4;
            this.CtrlClientsText.Text = "0";
            this.CtrlClientsText.Visible = false;
            this.CtrlClientsText.Click += new System.EventHandler(this.CtrlClientsText_Click);
            // 
            // CtrlServerStartButton
            // 
            this.CtrlServerStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlServerStartButton.Enabled = false;
            this.CtrlServerStartButton.Location = new System.Drawing.Point(925, 0);
            this.CtrlServerStartButton.Name = "CtrlServerStartButton";
            this.CtrlServerStartButton.Size = new System.Drawing.Size(55, 23);
            this.CtrlServerStartButton.TabIndex = 2;
            this.CtrlServerStartButton.Text = "Start";
            this.CtrlServerStartButton.UseVisualStyleBackColor = true;
            this.CtrlServerStartButton.Click += new System.EventHandler(this.CtrlServerStartButton_Click);
            // 
            // CtrlServerStatusText
            // 
            this.CtrlServerStatusText.AutoSize = true;
            this.CtrlServerStatusText.BackColor = System.Drawing.Color.White;
            this.CtrlServerStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlServerStatusText.ForeColor = System.Drawing.Color.Red;
            this.CtrlServerStatusText.Location = new System.Drawing.Point(230, 0);
            this.CtrlServerStatusText.Name = "CtrlServerStatusText";
            this.CtrlServerStatusText.Size = new System.Drawing.Size(49, 15);
            this.CtrlServerStatusText.TabIndex = 1;
            this.CtrlServerStatusText.Text = "Offline";
            // 
            // CtrlLogListView
            // 
            this.CtrlLogListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlLogListView.BackColor = System.Drawing.Color.Black;
            this.CtrlLogListView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlLogListView.ForeColor = System.Drawing.Color.White;
            this.CtrlLogListView.FullRowSelect = true;
            this.CtrlLogListView.Location = new System.Drawing.Point(0, 62);
            this.CtrlLogListView.Name = "CtrlLogListView";
            this.CtrlLogListView.Size = new System.Drawing.Size(983, 110);
            this.CtrlLogListView.TabIndex = 2;
            this.CtrlLogListView.UseCompatibleStateImageBehavior = false;
            this.CtrlLogListView.View = System.Windows.Forms.View.Details;
            this.CtrlLogListView.VirtualMode = true;
            this.CtrlLogListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.CtrlLogListView_RetrieveVirtualItem);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.modemToolStripMenuItem,
            this.geofencesMonitoringCenterToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.commadToolStripMenuItem,
            this.trafficToolStripMenuItem,
            this.viewTracfficSignalToolStripMenuItem,
            this.clearDeviceCountToolStripMenuItem,
            this.adminLoginToolStripMenuItem,
            this.autoFenceTimerToolStripMenuItem,
            this.lockSystemToolStripMenuItem});
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.configureToolStripMenuItem.Text = "Configure";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.databaseToolStripMenuItem.Text = "Database Connection";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // commadToolStripMenuItem
            // 
            this.commadToolStripMenuItem.Name = "commadToolStripMenuItem";
            this.commadToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.commadToolStripMenuItem.Text = "Set PORT";
            this.commadToolStripMenuItem.Click += new System.EventHandler(this.commadToolStripMenuItem_Click);
            // 
            // trafficToolStripMenuItem
            // 
            this.trafficToolStripMenuItem.Name = "trafficToolStripMenuItem";
            this.trafficToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.trafficToolStripMenuItem.Text = "Clear Traffic Signal";
            this.trafficToolStripMenuItem.Click += new System.EventHandler(this.trafficToolStripMenuItem_Click);
            // 
            // viewTracfficSignalToolStripMenuItem
            // 
            this.viewTracfficSignalToolStripMenuItem.Name = "viewTracfficSignalToolStripMenuItem";
            this.viewTracfficSignalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.viewTracfficSignalToolStripMenuItem.Text = "View Tracffic Signal";
            this.viewTracfficSignalToolStripMenuItem.Click += new System.EventHandler(this.viewTracfficSignalToolStripMenuItem_Click);
            // 
            // clearDeviceCountToolStripMenuItem
            // 
            this.clearDeviceCountToolStripMenuItem.Name = "clearDeviceCountToolStripMenuItem";
            this.clearDeviceCountToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.clearDeviceCountToolStripMenuItem.Text = "Clear Device Count";
            this.clearDeviceCountToolStripMenuItem.Click += new System.EventHandler(this.clearDeviceCountToolStripMenuItem_Click);
            // 
            // adminLoginToolStripMenuItem
            // 
            this.adminLoginToolStripMenuItem.Name = "adminLoginToolStripMenuItem";
            this.adminLoginToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.adminLoginToolStripMenuItem.Text = "Setting Admin Login";
            this.adminLoginToolStripMenuItem.Click += new System.EventHandler(this.adminLoginToolStripMenuItem_Click);
            // 
            // autoFenceTimerToolStripMenuItem
            // 
            this.autoFenceTimerToolStripMenuItem.Name = "autoFenceTimerToolStripMenuItem";
            this.autoFenceTimerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.autoFenceTimerToolStripMenuItem.Text = "AutoFenceTimer";
            this.autoFenceTimerToolStripMenuItem.Visible = false;
            this.autoFenceTimerToolStripMenuItem.Click += new System.EventHandler(this.autoFenceTimerToolStripMenuItem_Click);
            // 
            // lockSystemToolStripMenuItem
            // 
            this.lockSystemToolStripMenuItem.Name = "lockSystemToolStripMenuItem";
            this.lockSystemToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.lockSystemToolStripMenuItem.Text = "Lock System";
            this.lockSystemToolStripMenuItem.Click += new System.EventHandler(this.lockSystemToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subscriberAccountToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // subscriberAccountToolStripMenuItem
            // 
            this.subscriberAccountToolStripMenuItem.Name = "subscriberAccountToolStripMenuItem";
            this.subscriberAccountToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.subscriberAccountToolStripMenuItem.Text = "Subscriber Account";
            this.subscriberAccountToolStripMenuItem.Click += new System.EventHandler(this.subscriberAccountToolStripMenuItem_Click);
            // 
            // modemToolStripMenuItem
            // 
            this.modemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMSToolStripMenuItem,
            this.launchProgramToolStripMenuItem});
            this.modemToolStripMenuItem.Name = "modemToolStripMenuItem";
            this.modemToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.modemToolStripMenuItem.Text = "SMS Alert Console";
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.sMSToolStripMenuItem.Text = "Set Program Path";
            this.sMSToolStripMenuItem.Click += new System.EventHandler(this.sMSToolStripMenuItem_Click);
            // 
            // launchProgramToolStripMenuItem
            // 
            this.launchProgramToolStripMenuItem.Name = "launchProgramToolStripMenuItem";
            this.launchProgramToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.launchProgramToolStripMenuItem.Text = "Launch Program";
            this.launchProgramToolStripMenuItem.Click += new System.EventHandler(this.launchProgramToolStripMenuItem_Click);
            // 
            // geofencesMonitoringCenterToolStripMenuItem
            // 
            this.geofencesMonitoringCenterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUrlToolStripMenuItem,
            this.activatedToolStripMenuItem});
            this.geofencesMonitoringCenterToolStripMenuItem.Name = "geofencesMonitoringCenterToolStripMenuItem";
            this.geofencesMonitoringCenterToolStripMenuItem.Size = new System.Drawing.Size(175, 20);
            this.geofencesMonitoringCenterToolStripMenuItem.Text = "Geofences Monitoring Center";
            this.geofencesMonitoringCenterToolStripMenuItem.Click += new System.EventHandler(this.geofencesMonitoringCenterToolStripMenuItem_Click);
            // 
            // setUrlToolStripMenuItem
            // 
            this.setUrlToolStripMenuItem.Name = "setUrlToolStripMenuItem";
            this.setUrlToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.setUrlToolStripMenuItem.Text = "Set Url";
            this.setUrlToolStripMenuItem.Click += new System.EventHandler(this.setUrlToolStripMenuItem_Click);
            // 
            // activatedToolStripMenuItem
            // 
            this.activatedToolStripMenuItem.Name = "activatedToolStripMenuItem";
            this.activatedToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.activatedToolStripMenuItem.Text = "Start";
            this.activatedToolStripMenuItem.Click += new System.EventHandler(this.activatedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.aboutToolStripMenuItem2});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.aboutToolStripMenuItem1.Text = "User Manual";
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
            this.aboutToolStripMenuItem2.Text = "About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "GPRS/GPS Traffic Signal - Agensi Angkasa Negara-MALAYSIA";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(517, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDB.ForeColor = System.Drawing.Color.White;
            this.labelDB.Location = new System.Drawing.Point(637, 0);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(72, 15);
            this.labelDB.TabIndex = 3;
            this.labelDB.Text = "Database:";
            // 
            // labelDBserver
            // 
            this.labelDBserver.AutoSize = true;
            this.labelDBserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDBserver.ForeColor = System.Drawing.Color.White;
            this.labelDBserver.Location = new System.Drawing.Point(501, 0);
            this.labelDBserver.Name = "labelDBserver";
            this.labelDBserver.Size = new System.Drawing.Size(52, 15);
            this.labelDBserver.TabIndex = 2;
            this.labelDBserver.Text = "Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(559, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(443, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDeviceCount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.labelCountedPacket);
            this.panel1.Controls.Add(this.labelDeviceConnected);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(3, 465);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 33);
            this.panel1.TabIndex = 8;
            // 
            // labelDeviceCount
            // 
            this.labelDeviceCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeviceCount.AutoSize = true;
            this.labelDeviceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceCount.ForeColor = System.Drawing.Color.White;
            this.labelDeviceCount.Location = new System.Drawing.Point(1054, 8);
            this.labelDeviceCount.Name = "labelDeviceCount";
            this.labelDeviceCount.Size = new System.Drawing.Size(15, 15);
            this.labelDeviceCount.TabIndex = 10;
            this.labelDeviceCount.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1004, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Device";
            // 
            // labelCountedPacket
            // 
            this.labelCountedPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCountedPacket.AutoSize = true;
            this.labelCountedPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountedPacket.ForeColor = System.Drawing.Color.White;
            this.labelCountedPacket.Location = new System.Drawing.Point(970, 7);
            this.labelCountedPacket.Name = "labelCountedPacket";
            this.labelCountedPacket.Size = new System.Drawing.Size(15, 15);
            this.labelCountedPacket.TabIndex = 8;
            this.labelCountedPacket.Text = "0";
            // 
            // labelDeviceConnected
            // 
            this.labelDeviceConnected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeviceConnected.AutoSize = true;
            this.labelDeviceConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceConnected.ForeColor = System.Drawing.Color.White;
            this.labelDeviceConnected.Location = new System.Drawing.Point(805, 9);
            this.labelDeviceConnected.Name = "labelDeviceConnected";
            this.labelDeviceConnected.Size = new System.Drawing.Size(95, 15);
            this.labelDeviceConnected.TabIndex = 7;
            this.labelDeviceConnected.Text = "Device Count:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelDB, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.CtrlClientsText, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelProgramStarted, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CtrlServerStatusText, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDBserver, 8, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 23);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(285, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Clients Connected :";
            this.label6.Visible = false;
            // 
            // labelProgramStarted
            // 
            this.labelProgramStarted.AutoSize = true;
            this.labelProgramStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgramStarted.ForeColor = System.Drawing.Color.White;
            this.labelProgramStarted.Location = new System.Drawing.Point(88, 0);
            this.labelProgramStarted.Name = "labelProgramStarted";
            this.labelProgramStarted.Size = new System.Drawing.Size(79, 15);
            this.labelProgramStarted.TabIndex = 1;
            this.labelProgramStarted.Text = "Started On:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Started On:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(173, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = " Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "label7";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelSMSAgentStatus);
            this.panel2.Controls.Add(this.labellogin);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 33);
            this.panel2.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(593, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Geofence Agent:N/A";
            // 
            // labelSMSAgentStatus
            // 
            this.labelSMSAgentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSMSAgentStatus.AutoSize = true;
            this.labelSMSAgentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSMSAgentStatus.ForeColor = System.Drawing.Color.White;
            this.labelSMSAgentStatus.Location = new System.Drawing.Point(752, 7);
            this.labelSMSAgentStatus.Name = "labelSMSAgentStatus";
            this.labelSMSAgentStatus.Size = new System.Drawing.Size(101, 15);
            this.labelSMSAgentStatus.TabIndex = 9;
            this.labelSMSAgentStatus.Text = "Sms Agent:N/A";
            // 
            // labellogin
            // 
            this.labellogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labellogin.AutoSize = true;
            this.labellogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellogin.ForeColor = System.Drawing.Color.White;
            this.labellogin.Location = new System.Drawing.Point(914, 7);
            this.labellogin.Name = "labellogin";
            this.labellogin.Size = new System.Drawing.Size(54, 15);
            this.labellogin.TabIndex = 8;
            this.labellogin.Text = "Norhan";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(880, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Log:";
            // 
            // listBoxGPSpacket
            // 
            this.listBoxGPSpacket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxGPSpacket.BackColor = System.Drawing.Color.Black;
            this.listBoxGPSpacket.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGPSpacket.ForeColor = System.Drawing.Color.White;
            this.listBoxGPSpacket.FormattingEnabled = true;
            this.listBoxGPSpacket.ItemHeight = 17;
            this.listBoxGPSpacket.Location = new System.Drawing.Point(0, 34);
            this.listBoxGPSpacket.Name = "listBoxGPSpacket";
            this.listBoxGPSpacket.Size = new System.Drawing.Size(984, 429);
            this.listBoxGPSpacket.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(991, 530);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(983, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listBoxGPSpacket);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(977, 498);
            this.panel3.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(983, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(977, 498);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 531);
            this.Controls.Add(this.CtrlServerStartButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CtrlServerGroup);
            this.Controls.Add(this.CtrlDeviceGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CtrlLogListView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Fence Administrator Program";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.CtrlDeviceGroup.ResumeLayout(false);
            this.CtrlDeviceGroup.PerformLayout();
            this.CtrlServerGroup.ResumeLayout(false);
            this.CtrlServerGroup.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox CtrlDeviceGroup;
		private System.Windows.Forms.ComboBox CtrlDeviceList;
		private System.Windows.Forms.Label CtrlDeviceLabel;
		private System.Windows.Forms.Button CtrlDeviceEditButton;
		private System.Windows.Forms.GroupBox CtrlServerGroup;
		private System.Windows.Forms.Label CtrlServerStatusText;
		private System.Windows.Forms.Label CtrlServerStatusLabel;
		private System.Windows.Forms.Button CtrlServerStartButton;
		private System.Windows.Forms.Label CtrlClientsLabel;
		private System.Windows.Forms.Label CtrlClientsText;
		private System.Windows.Forms.ListView CtrlLogListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commadToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label labelDB;
        public System.Windows.Forms.Label labelDBserver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelProgramStarted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelDeviceConnected;
        private System.Windows.Forms.ToolStripMenuItem modemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCountedPacket;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelDeviceCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxGPSpacket;
        private System.Windows.Forms.ToolStripMenuItem trafficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriberAccountToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem geofencesMonitoringCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTracfficSignalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.Label labellogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelSMSAgentStatus;
        private System.Windows.Forms.ToolStripMenuItem clearDeviceCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoFenceTimerToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;

	}
}

