namespace GPSAgent.Components.Form
{
	partial class FormEdit
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
            this.CtrlDeviceLabel = new System.Windows.Forms.Label();
            this.CtrlDeviceNameText = new System.Windows.Forms.Label();
            this.CtrlServerGroup = new System.Windows.Forms.GroupBox();
            this.CtrlServerMaxConnText = new System.Windows.Forms.TextBox();
            this.CtrlMaxConnLabel = new System.Windows.Forms.Label();
            this.CtrlServerPortText = new System.Windows.Forms.TextBox();
            this.CtrlServerPortLabel = new System.Windows.Forms.Label();
            this.CtrlServerProtocolList = new System.Windows.Forms.ComboBox();
            this.CtrlServerProtocolLabel = new System.Windows.Forms.Label();
            this.CtrlSaveButton = new System.Windows.Forms.Button();
            this.CtrlServerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlDeviceLabel
            // 
            this.CtrlDeviceLabel.AutoSize = true;
            this.CtrlDeviceLabel.Location = new System.Drawing.Point(26, 13);
            this.CtrlDeviceLabel.Name = "CtrlDeviceLabel";
            this.CtrlDeviceLabel.Size = new System.Drawing.Size(82, 13);
            this.CtrlDeviceLabel.TabIndex = 0;
            this.CtrlDeviceLabel.Text = "Device Model :";
            // 
            // CtrlDeviceNameText
            // 
            this.CtrlDeviceNameText.AutoSize = true;
            this.CtrlDeviceNameText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlDeviceNameText.ForeColor = System.Drawing.Color.Blue;
            this.CtrlDeviceNameText.Location = new System.Drawing.Point(104, 13);
            this.CtrlDeviceNameText.Name = "CtrlDeviceNameText";
            this.CtrlDeviceNameText.Size = new System.Drawing.Size(0, 13);
            this.CtrlDeviceNameText.TabIndex = 1;
            // 
            // CtrlServerGroup
            // 
            this.CtrlServerGroup.Controls.Add(this.CtrlServerMaxConnText);
            this.CtrlServerGroup.Controls.Add(this.CtrlMaxConnLabel);
            this.CtrlServerGroup.Controls.Add(this.CtrlServerPortText);
            this.CtrlServerGroup.Controls.Add(this.CtrlServerPortLabel);
            this.CtrlServerGroup.Controls.Add(this.CtrlServerProtocolList);
            this.CtrlServerGroup.Controls.Add(this.CtrlServerProtocolLabel);
            this.CtrlServerGroup.Location = new System.Drawing.Point(12, 37);
            this.CtrlServerGroup.Name = "CtrlServerGroup";
            this.CtrlServerGroup.Size = new System.Drawing.Size(222, 116);
            this.CtrlServerGroup.TabIndex = 2;
            this.CtrlServerGroup.TabStop = false;
            this.CtrlServerGroup.Text = "Server";
            // 
            // CtrlServerMaxConnText
            // 
            this.CtrlServerMaxConnText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlServerMaxConnText.Location = new System.Drawing.Point(143, 79);
            this.CtrlServerMaxConnText.Name = "CtrlServerMaxConnText";
            this.CtrlServerMaxConnText.Size = new System.Drawing.Size(64, 22);
            this.CtrlServerMaxConnText.TabIndex = 5;
            // 
            // CtrlMaxConnLabel
            // 
            this.CtrlMaxConnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlMaxConnLabel.AutoSize = true;
            this.CtrlMaxConnLabel.Location = new System.Drawing.Point(10, 83);
            this.CtrlMaxConnLabel.Name = "CtrlMaxConnLabel";
            this.CtrlMaxConnLabel.Size = new System.Drawing.Size(130, 13);
            this.CtrlMaxConnLabel.TabIndex = 4;
            this.CtrlMaxConnLabel.Text = "Maximum Connections :";
            this.CtrlMaxConnLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CtrlServerPortText
            // 
            this.CtrlServerPortText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlServerPortText.Location = new System.Drawing.Point(143, 51);
            this.CtrlServerPortText.MaxLength = 5;
            this.CtrlServerPortText.Name = "CtrlServerPortText";
            this.CtrlServerPortText.Size = new System.Drawing.Size(64, 22);
            this.CtrlServerPortText.TabIndex = 3;
            // 
            // CtrlServerPortLabel
            // 
            this.CtrlServerPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlServerPortLabel.AutoSize = true;
            this.CtrlServerPortLabel.Location = new System.Drawing.Point(105, 54);
            this.CtrlServerPortLabel.Name = "CtrlServerPortLabel";
            this.CtrlServerPortLabel.Size = new System.Drawing.Size(34, 13);
            this.CtrlServerPortLabel.TabIndex = 2;
            this.CtrlServerPortLabel.Text = "Port :";
            this.CtrlServerPortLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CtrlServerProtocolList
            // 
            this.CtrlServerProtocolList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlServerProtocolList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CtrlServerProtocolList.FormattingEnabled = true;
            this.CtrlServerProtocolList.Location = new System.Drawing.Point(143, 24);
            this.CtrlServerProtocolList.Name = "CtrlServerProtocolList";
            this.CtrlServerProtocolList.Size = new System.Drawing.Size(64, 21);
            this.CtrlServerProtocolList.TabIndex = 1;
            // 
            // CtrlServerProtocolLabel
            // 
            this.CtrlServerProtocolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlServerProtocolLabel.AutoSize = true;
            this.CtrlServerProtocolLabel.Location = new System.Drawing.Point(83, 28);
            this.CtrlServerProtocolLabel.Name = "CtrlServerProtocolLabel";
            this.CtrlServerProtocolLabel.Size = new System.Drawing.Size(56, 13);
            this.CtrlServerProtocolLabel.TabIndex = 0;
            this.CtrlServerProtocolLabel.Text = "Protocol :";
            this.CtrlServerProtocolLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CtrlSaveButton
            // 
            this.CtrlSaveButton.Location = new System.Drawing.Point(95, 173);
            this.CtrlSaveButton.Name = "CtrlSaveButton";
            this.CtrlSaveButton.Size = new System.Drawing.Size(65, 23);
            this.CtrlSaveButton.TabIndex = 3;
            this.CtrlSaveButton.Text = "Save";
            this.CtrlSaveButton.UseVisualStyleBackColor = true;
            this.CtrlSaveButton.Click += new System.EventHandler(this.CtrlSaveButton_Click);
            // 
            // FormEdit
            // 
            this.AcceptButton = this.CtrlSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 207);
            this.Controls.Add(this.CtrlDeviceNameText);
            this.Controls.Add(this.CtrlSaveButton);
            this.Controls.Add(this.CtrlServerGroup);
            this.Controls.Add(this.CtrlDeviceLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
           
            this.CtrlServerGroup.ResumeLayout(false);
            this.CtrlServerGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label CtrlDeviceLabel;
		private System.Windows.Forms.GroupBox CtrlServerGroup;
		private System.Windows.Forms.ComboBox CtrlServerProtocolList;
		private System.Windows.Forms.Label CtrlServerProtocolLabel;
		private System.Windows.Forms.Button CtrlSaveButton;
		private System.Windows.Forms.Label CtrlDeviceNameText;
		private System.Windows.Forms.TextBox CtrlServerPortText;
		private System.Windows.Forms.Label CtrlServerPortLabel;
		private System.Windows.Forms.TextBox CtrlServerMaxConnText;
		private System.Windows.Forms.Label CtrlMaxConnLabel;
	}
}