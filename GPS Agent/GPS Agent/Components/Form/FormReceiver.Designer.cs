namespace GPSAgent.Components.Form
{
    partial class FormReceiver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReceiver));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxGPSTraffic = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDeviceCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxWorklistServerIPPort = new System.Windows.Forms.TextBox();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.buttonStartListerning = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCount = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(210, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startListenerToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.controlToolStripMenuItem.Text = "control";
            // 
            // startListenerToolStripMenuItem
            // 
            this.startListenerToolStripMenuItem.Name = "startListenerToolStripMenuItem";
            this.startListenerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.startListenerToolStripMenuItem.Text = "Start Server";
            this.startListenerToolStripMenuItem.Click += new System.EventHandler(this.startListenerToolStripMenuItem_Click);
            // 
            // listBoxGPSTraffic
            // 
            this.listBoxGPSTraffic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxGPSTraffic.BackColor = System.Drawing.Color.Black;
            this.listBoxGPSTraffic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGPSTraffic.ForeColor = System.Drawing.Color.White;
            this.listBoxGPSTraffic.FormattingEnabled = true;
            this.listBoxGPSTraffic.ItemHeight = 16;
            this.listBoxGPSTraffic.Location = new System.Drawing.Point(0, 94);
            this.listBoxGPSTraffic.Name = "listBoxGPSTraffic";
            this.listBoxGPSTraffic.Size = new System.Drawing.Size(1032, 548);
            this.listBoxGPSTraffic.TabIndex = 13;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelDeviceCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 642);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabel1.Text = "Device Counted:";
            // 
            // toolStripStatusLabelDeviceCount
            // 
            this.toolStripStatusLabelDeviceCount.Name = "toolStripStatusLabelDeviceCount";
            this.toolStripStatusLabelDeviceCount.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelDeviceCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port";
            // 
            // textBoxWorklistServerIPPort
            // 
            this.textBoxWorklistServerIPPort.Location = new System.Drawing.Point(49, 37);
            this.textBoxWorklistServerIPPort.Name = "textBoxWorklistServerIPPort";
            this.textBoxWorklistServerIPPort.Size = new System.Drawing.Size(149, 20);
            this.textBoxWorklistServerIPPort.TabIndex = 15;
            this.textBoxWorklistServerIPPort.Text = "5501";
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(215, 35);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(149, 22);
            this.buttonStartServer.TabIndex = 17;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonStartListerning
            // 
            this.buttonStartListerning.Location = new System.Drawing.Point(215, 63);
            this.buttonStartListerning.Name = "buttonStartListerning";
            this.buttonStartListerning.Size = new System.Drawing.Size(149, 25);
            this.buttonStartListerning.TabIndex = 18;
            this.buttonStartListerning.Text = "Start Listerning";
            this.buttonStartListerning.UseVisualStyleBackColor = true;
            this.buttonStartListerning.Click += new System.EventHandler(this.buttonStartListerning_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(973, 647);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(13, 13);
            this.labelCount.TabIndex = 19;
            this.labelCount.Text = "0";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.modemToolStripMenuItem,
            this.geofencesMonitoringCenterToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip2.TabIndex = 20;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
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
            this.geofencesMonitoringCenterToolStripMenuItem.Visible = false;
            // 
            // setUrlToolStripMenuItem
            // 
            this.setUrlToolStripMenuItem.Name = "setUrlToolStripMenuItem";
            this.setUrlToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.setUrlToolStripMenuItem.Text = "Set Url";
            // 
            // activatedToolStripMenuItem
            // 
            this.activatedToolStripMenuItem.Name = "activatedToolStripMenuItem";
            this.activatedToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.activatedToolStripMenuItem.Text = "Start";
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
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Mosti Track Administrator Program";
            this.notifyIcon1.BalloonTipTitle = "Mosti Track Administrator Program";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Mosti Track Administrator Program";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // FormReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 664);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonStartListerning);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWorklistServerIPPort);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBoxGPSTraffic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormReceiver";
            this.Text = "MOSTI TRACK ADMINISTRATOR PROGRAM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReceiver_FormClosing);
            this.Resize += new System.EventHandler(this.FormReceiver_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startListenerToolStripMenuItem;
        public System.Windows.Forms.ListBox listBoxGPSTraffic;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWorklistServerIPPort;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Button buttonStartListerning;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDeviceCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trafficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTracfficSignalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDeviceCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoFenceTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriberAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geofencesMonitoringCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}