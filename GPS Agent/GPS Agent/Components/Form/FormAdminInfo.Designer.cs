namespace GPSAgent.Components.Form
{
    partial class FormAdminInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAdminUserName1 = new System.Windows.Forms.TextBox();
            this.textBoxAdminPassword1 = new System.Windows.Forms.TextBox();
            this.textBoxAdminUserName2 = new System.Windows.Forms.TextBox();
            this.textBoxAdminPassword2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAdminPassword2);
            this.groupBox1.Controls.Add(this.textBoxAdminUserName2);
            this.groupBox1.Controls.Add(this.textBoxAdminPassword1);
            this.groupBox1.Controls.Add(this.textBoxAdminUserName1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Admin Login Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin User Name 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Admin Password 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Admin Password 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Admin User Name 2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxAdminUserName1
            // 
            this.textBoxAdminUserName1.Location = new System.Drawing.Point(145, 26);
            this.textBoxAdminUserName1.Name = "textBoxAdminUserName1";
            this.textBoxAdminUserName1.Size = new System.Drawing.Size(163, 20);
            this.textBoxAdminUserName1.TabIndex = 5;
            // 
            // textBoxAdminPassword1
            // 
            this.textBoxAdminPassword1.Location = new System.Drawing.Point(145, 52);
            this.textBoxAdminPassword1.Name = "textBoxAdminPassword1";
            this.textBoxAdminPassword1.Size = new System.Drawing.Size(163, 20);
            this.textBoxAdminPassword1.TabIndex = 6;
            // 
            // textBoxAdminUserName2
            // 
            this.textBoxAdminUserName2.Location = new System.Drawing.Point(145, 96);
            this.textBoxAdminUserName2.Name = "textBoxAdminUserName2";
            this.textBoxAdminUserName2.Size = new System.Drawing.Size(163, 20);
            this.textBoxAdminUserName2.TabIndex = 7;
            // 
            // textBoxAdminPassword2
            // 
            this.textBoxAdminPassword2.Location = new System.Drawing.Point(145, 121);
            this.textBoxAdminPassword2.Name = "textBoxAdminPassword2";
            this.textBoxAdminPassword2.Size = new System.Drawing.Size(163, 20);
            this.textBoxAdminPassword2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-17, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(385, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "_______________________________________________________________";
            // 
            // FormAdminInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 188);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAdminInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Login";
            this.Load += new System.EventHandler(this.FormAdminInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAdminPassword2;
        private System.Windows.Forms.TextBox textBoxAdminUserName2;
        private System.Windows.Forms.TextBox textBoxAdminPassword1;
        private System.Windows.Forms.TextBox textBoxAdminUserName1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}