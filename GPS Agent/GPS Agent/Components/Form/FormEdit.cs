using System;
using System.Drawing;
using System.Windows.Forms;
using GPSAgent.Data;




namespace GPSAgent.Components.Form
{
	public partial class FormEdit : System.Windows.Forms.Form
	{
		private GPSTracker m_GPSTracker = null;


		public FormEdit(GPSTracker oGPSTracker)
		{
			
			InitializeComponent();

			this.m_GPSTracker = oGPSTracker;
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			this.CtrlDeviceNameText.Text = this.m_GPSTracker.Model.ToString();
			this.CtrlServerPortText.Text = this.m_GPSTracker.ServerPort.ToString();
			this.CtrlServerProtocolList.Items.Add(this.m_GPSTracker.ServerProtocol);	// Currently on support TCP server
			this.CtrlServerProtocolList.SelectedIndex = 0;
			this.CtrlServerMaxConnText.Text = this.m_GPSTracker.ServerMaxConnections.ToString();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				if (this.ControlBox)
				{
					this.Close();
					return true;
				}
			}
			return base.ProcessDialogKey(keyData);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			using (Pen p = new Pen(Color.Gray))
			{
				e.Graphics.DrawLine(p,
									16,
									20,
									this.ClientRectangle.Right - 18,
									20);
			}

			base.OnPaint(e);
		}
		private void CtrlSaveButton_Click(object sender, EventArgs e)
		{
			int iPort = 0;
			int iMaxConn = 100;
			if (int.TryParse(this.CtrlServerPortText.Text, out iPort) == false)
			{
				MessageBox.Show("Please enter a valid Port value.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else if ((iPort >= 0 && iPort <= 0xFFFF) == false)
			{
				MessageBox.Show("Please enter a valid Port value ranging from 0 to 65535.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (int.TryParse(this.CtrlServerMaxConnText.Text, out iMaxConn) == false)
			{
				MessageBox.Show("Please enter a valid Maximum Connections value.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else if ((iMaxConn >= 1 && iMaxConn <= 1000) == false)
			{
				MessageBox.Show("Please enter a valid Maximum Connections value ranging from 1 to 1000.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			this.m_GPSTracker.ServerPort = iPort;
			this.m_GPSTracker.ServerMaxConnections = iMaxConn;
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		public GPSTracker GPSTracker
		{
			get { return this.m_GPSTracker; }
		}

    
	}
}
