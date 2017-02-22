using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPSAgent.Components.Form
{
    public partial class FormGPSTrackerDeviceList : System.Windows.Forms.Form
    {
        DB oo = new DB();
        public FormGPSTrackerDeviceList()
        {
            InitializeComponent();
        }

        private void buttonLoadAllGPSDevices_Click(object sender, EventArgs e)
        {
            trackerDeviceDataGridView.DataSource = oo.GPSDevicesAll();
            trackerDeviceDataGridView.DataMember = "GPSDevicesAll";
        }

        private void buttonSearchGPSDevices_Click(object sender, EventArgs e)
        {
            trackerDeviceDataGridView.DataSource = oo.GPSDevicesSearchCol(textBoxGPSDeviceSearch.Text);
            trackerDeviceDataGridView.DataMember = "GPSDevicesSearchCol";
        }

        private void FormGPSTrackerDeviceList_Load(object sender, EventArgs e)
        {
            trackerDeviceDataGridView.DataSource = oo.GPSDevicesAll();
            trackerDeviceDataGridView.DataMember = "GPSDevicesAll";

        }

        private void trackerDeviceDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = trackerDeviceDataGridView.Rows[e.RowIndex].Index.ToString();
            string cellValue =trackerDeviceDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            FormAddNewTrackingItem i = (FormAddNewTrackingItem)Application.OpenForms["FormAddNewTrackingItem"];
            i.deviceIDTextBox.Text = cellValue;
        }
    }
}
