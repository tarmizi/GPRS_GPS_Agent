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
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.listBoxGPSTraffic.ForeColor = System.Drawing.Color.White;
            this.listBoxGPSTraffic.FormattingEnabled = true;
            this.listBoxGPSTraffic.Location = new System.Drawing.Point(0, 94);
            this.listBoxGPSTraffic.Name = "listBoxGPSTraffic";
            this.listBoxGPSTraffic.Size = new System.Drawing.Size(1032, 550);
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
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port";
            // 
            // textBoxWorklistServerIPPort
            // 
            this.textBoxWorklistServerIPPort.Location = new System.Drawing.Point(49, 12);
            this.textBoxWorklistServerIPPort.Name = "textBoxWorklistServerIPPort";
            this.textBoxWorklistServerIPPort.Size = new System.Drawing.Size(149, 20);
            this.textBoxWorklistServerIPPort.TabIndex = 15;
            this.textBoxWorklistServerIPPort.Text = "5501";
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(49, 38);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(149, 22);
            this.buttonStartServer.TabIndex = 17;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonStartListerning
            // 
            this.buttonStartListerning.Location = new System.Drawing.Point(49, 66);
            this.buttonStartListerning.Name = "buttonStartListerning";
            this.buttonStartListerning.Size = new System.Drawing.Size(149, 25);
            this.buttonStartListerning.TabIndex = 18;
            this.buttonStartListerning.Text = "Start Listerning";
            this.buttonStartListerning.UseVisualStyleBackColor = true;
            this.buttonStartListerning.Click += new System.EventHandler(this.buttonStartListerning_Click);
            // 
            // FormReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 664);
            this.Controls.Add(this.buttonStartListerning);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWorklistServerIPPort);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBoxGPSTraffic);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormReceiver";
            this.Text = "GPS/GPRS Receiver";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}