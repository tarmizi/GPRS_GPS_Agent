namespace GPSAgent.Components.Form
{
    partial class FormGPSTrackerDeviceList
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
            this.panelHeaderGPSDevices = new System.Windows.Forms.Panel();
            this.buttonLoadAllGPSDevices = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSearchGPSDevices = new System.Windows.Forms.Button();
            this.textBoxGPSDeviceSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackerDeviceDataGridView = new System.Windows.Forms.DataGridView();
            this.panelHeaderGPSDevices.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackerDeviceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeaderGPSDevices
            // 
            this.panelHeaderGPSDevices.Controls.Add(this.buttonLoadAllGPSDevices);
            this.panelHeaderGPSDevices.Controls.Add(this.label6);
            this.panelHeaderGPSDevices.Controls.Add(this.buttonSearchGPSDevices);
            this.panelHeaderGPSDevices.Controls.Add(this.textBoxGPSDeviceSearch);
            this.panelHeaderGPSDevices.Controls.Add(this.label7);
            this.panelHeaderGPSDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderGPSDevices.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderGPSDevices.Name = "panelHeaderGPSDevices";
            this.panelHeaderGPSDevices.Size = new System.Drawing.Size(886, 30);
            this.panelHeaderGPSDevices.TabIndex = 2;
            // 
            // buttonLoadAllGPSDevices
            // 
            this.buttonLoadAllGPSDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadAllGPSDevices.Location = new System.Drawing.Point(809, 4);
            this.buttonLoadAllGPSDevices.Name = "buttonLoadAllGPSDevices";
            this.buttonLoadAllGPSDevices.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadAllGPSDevices.TabIndex = 9;
            this.buttonLoadAllGPSDevices.Text = "Load All";
            this.buttonLoadAllGPSDevices.UseVisualStyleBackColor = true;
            this.buttonLoadAllGPSDevices.Click += new System.EventHandler(this.buttonLoadAllGPSDevices_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "(Search By Account No,Track ID,Device ID)";
            // 
            // buttonSearchGPSDevices
            // 
            this.buttonSearchGPSDevices.Location = new System.Drawing.Point(322, 4);
            this.buttonSearchGPSDevices.Name = "buttonSearchGPSDevices";
            this.buttonSearchGPSDevices.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchGPSDevices.TabIndex = 7;
            this.buttonSearchGPSDevices.Text = "Search";
            this.buttonSearchGPSDevices.UseVisualStyleBackColor = true;
            this.buttonSearchGPSDevices.Click += new System.EventHandler(this.buttonSearchGPSDevices_Click);
            // 
            // textBoxGPSDeviceSearch
            // 
            this.textBoxGPSDeviceSearch.Location = new System.Drawing.Point(52, 5);
            this.textBoxGPSDeviceSearch.Name = "textBoxGPSDeviceSearch";
            this.textBoxGPSDeviceSearch.Size = new System.Drawing.Size(264, 20);
            this.textBoxGPSDeviceSearch.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Search:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trackerDeviceDataGridView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(886, 421);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "All GPS Tracker Device";
            // 
            // trackerDeviceDataGridView
            // 
            this.trackerDeviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackerDeviceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackerDeviceDataGridView.Location = new System.Drawing.Point(3, 16);
            this.trackerDeviceDataGridView.Name = "trackerDeviceDataGridView";
            this.trackerDeviceDataGridView.Size = new System.Drawing.Size(880, 402);
            this.trackerDeviceDataGridView.TabIndex = 0;
            this.trackerDeviceDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.trackerDeviceDataGridView_CellDoubleClick);
            // 
            // FormGPSTrackerDeviceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panelHeaderGPSDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGPSTrackerDeviceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS Tracker Device List";
            this.Load += new System.EventHandler(this.FormGPSTrackerDeviceList_Load);
            this.panelHeaderGPSDevices.ResumeLayout(false);
            this.panelHeaderGPSDevices.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackerDeviceDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderGPSDevices;
        private System.Windows.Forms.Button buttonLoadAllGPSDevices;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSearchGPSDevices;
        private System.Windows.Forms.TextBox textBoxGPSDeviceSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView trackerDeviceDataGridView;
    }
}