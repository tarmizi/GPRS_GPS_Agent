namespace GPSAgent.Components.Form
{
    partial class FormDevice
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
            this.CtrlDeviceGroup = new System.Windows.Forms.GroupBox();
            this.CtrlDeviceEditButton = new System.Windows.Forms.Button();
            this.CtrlDeviceList = new System.Windows.Forms.ComboBox();
            this.CtrlDeviceLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CtrlDeviceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlDeviceGroup
            // 
            this.CtrlDeviceGroup.Controls.Add(this.CtrlDeviceEditButton);
            this.CtrlDeviceGroup.Controls.Add(this.CtrlDeviceList);
            this.CtrlDeviceGroup.Controls.Add(this.CtrlDeviceLabel);
            this.CtrlDeviceGroup.Location = new System.Drawing.Point(12, 12);
            this.CtrlDeviceGroup.Name = "CtrlDeviceGroup";
            this.CtrlDeviceGroup.Size = new System.Drawing.Size(240, 77);
            this.CtrlDeviceGroup.TabIndex = 1;
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
            // 
            // CtrlDeviceLabel
            // 
            this.CtrlDeviceLabel.AutoSize = true;
            this.CtrlDeviceLabel.Location = new System.Drawing.Point(17, 24);
            this.CtrlDeviceLabel.Name = "CtrlDeviceLabel";
            this.CtrlDeviceLabel.Size = new System.Drawing.Size(41, 13);
            this.CtrlDeviceLabel.TabIndex = 2;
            this.CtrlDeviceLabel.Text = "Name :";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 154);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running Device";
            // 
            // FormDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CtrlDeviceGroup);
            this.Name = "FormDevice";
            this.Text = "FormDevice";
            this.CtrlDeviceGroup.ResumeLayout(false);
            this.CtrlDeviceGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CtrlDeviceGroup;
        private System.Windows.Forms.Button CtrlDeviceEditButton;
        private System.Windows.Forms.ComboBox CtrlDeviceList;
        private System.Windows.Forms.Label CtrlDeviceLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}