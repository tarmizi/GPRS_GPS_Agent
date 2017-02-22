namespace GPSAgent.Components.Form
{
    partial class FormUserList
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gPSuserDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxAssignedAccNo = new System.Windows.Forms.TextBox();
            this.buttonRefreshAllUser = new System.Windows.Forms.Button();
            this.panelHeaderUser = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonLoadAllUser = new System.Windows.Forms.Button();
            this.buttonSearchAllUser = new System.Windows.Forms.Button();
            this.textBoxAllUserSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPSuserDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelHeaderUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gPSuserDataGridView);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 35);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(845, 453);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "All User";
            // 
            // gPSuserDataGridView
            // 
            this.gPSuserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPSuserDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPSuserDataGridView.Location = new System.Drawing.Point(3, 16);
            this.gPSuserDataGridView.Name = "gPSuserDataGridView";
            this.gPSuserDataGridView.Size = new System.Drawing.Size(839, 434);
            this.gPSuserDataGridView.TabIndex = 0;
            this.gPSuserDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gPSuserDataGridView_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxAssignedAccNo);
            this.panel1.Controls.Add(this.buttonRefreshAllUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 488);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 35);
            this.panel1.TabIndex = 7;
            // 
            // textBoxAssignedAccNo
            // 
            this.textBoxAssignedAccNo.Location = new System.Drawing.Point(733, -24);
            this.textBoxAssignedAccNo.Name = "textBoxAssignedAccNo";
            this.textBoxAssignedAccNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxAssignedAccNo.TabIndex = 4;
            // 
            // buttonRefreshAllUser
            // 
            this.buttonRefreshAllUser.Location = new System.Drawing.Point(4, 6);
            this.buttonRefreshAllUser.Name = "buttonRefreshAllUser";
            this.buttonRefreshAllUser.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshAllUser.TabIndex = 3;
            this.buttonRefreshAllUser.Text = "Refresh";
            this.buttonRefreshAllUser.UseVisualStyleBackColor = true;
            this.buttonRefreshAllUser.Click += new System.EventHandler(this.buttonRefreshAllUser_Click);
            // 
            // panelHeaderUser
            // 
            this.panelHeaderUser.Controls.Add(this.label8);
            this.panelHeaderUser.Controls.Add(this.buttonLoadAllUser);
            this.panelHeaderUser.Controls.Add(this.buttonSearchAllUser);
            this.panelHeaderUser.Controls.Add(this.textBoxAllUserSearch);
            this.panelHeaderUser.Controls.Add(this.label9);
            this.panelHeaderUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderUser.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderUser.Name = "panelHeaderUser";
            this.panelHeaderUser.Size = new System.Drawing.Size(845, 35);
            this.panelHeaderUser.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(358, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "(Search by UserName or Email or Phone Number)";
            // 
            // buttonLoadAllUser
            // 
            this.buttonLoadAllUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadAllUser.Location = new System.Drawing.Point(768, 6);
            this.buttonLoadAllUser.Name = "buttonLoadAllUser";
            this.buttonLoadAllUser.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadAllUser.TabIndex = 8;
            this.buttonLoadAllUser.Text = "Load All";
            this.buttonLoadAllUser.UseVisualStyleBackColor = true;
            this.buttonLoadAllUser.Click += new System.EventHandler(this.buttonLoadAllUser_Click);
            // 
            // buttonSearchAllUser
            // 
            this.buttonSearchAllUser.Location = new System.Drawing.Point(277, 6);
            this.buttonSearchAllUser.Name = "buttonSearchAllUser";
            this.buttonSearchAllUser.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchAllUser.TabIndex = 7;
            this.buttonSearchAllUser.Text = "Search";
            this.buttonSearchAllUser.UseVisualStyleBackColor = true;
            this.buttonSearchAllUser.Click += new System.EventHandler(this.buttonSearchAllUser_Click);
            // 
            // textBoxAllUserSearch
            // 
            this.textBoxAllUserSearch.Location = new System.Drawing.Point(61, 8);
            this.textBoxAllUserSearch.Name = "textBoxAllUserSearch";
            this.textBoxAllUserSearch.Size = new System.Drawing.Size(210, 20);
            this.textBoxAllUserSearch.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Search";
            // 
            // FormUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 523);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeaderUser);
            this.Name = "FormUserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All User";
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gPSuserDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHeaderUser.ResumeLayout(false);
            this.panelHeaderUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView gPSuserDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRefreshAllUser;
        private System.Windows.Forms.Panel panelHeaderUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonLoadAllUser;
        private System.Windows.Forms.Button buttonSearchAllUser;
        private System.Windows.Forms.TextBox textBoxAllUserSearch;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxAssignedAccNo;
    }
}