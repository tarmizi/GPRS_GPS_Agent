using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;




namespace GPSAgent.Components.Form
{
 
    public partial class FormAccountMain : System.Windows.Forms.Form
    {
        DB oo = new DB();
        FormMain f = new FormMain();
     
    

        string log;
        private string connstring;
        public FormAccountMain()
        {
            InitializeComponent();
        }

        private void registeredAccountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registeredAccountBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dB_9D78AD_trackingDBDataSet);

        }

        private void FormAccountMain_Load(object sender, EventArgs e)
        {
           
            log = f.labellogin.Text;
            tabControl1.SelectedTab = tabPageUser;
            labelHeaderTitle.Text = "All Registered User";
            ReloadUserList();
        }

        private void toolStripButtonSubscriberAccount_Click(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
            tabControl1.SelectedTab = tabPageAllList;
            labelHeaderTitle.Text = "All Accounts";
            dataGridViewAllAccounts.DataSource = oo.myAccount("LoadAllAccount");
            dataGridViewAllAccounts.DataMember = "AllAccount";
            labelRowsCountAllSubscriberAccount.Text = Convert.ToString(dataGridViewAllAccounts.RowCount - 1);
          //  labelHeaderTitle.Text = "All Accounts";
        }

        private void buttonLoadAllAccount_Click(object sender, EventArgs e)
        {
            dataGridViewAllAccounts.DataSource = oo.myAccount("LoadAllAccount");
            dataGridViewAllAccounts.DataMember = "AllAccount";
            labelHeaderTitle.Text = "All Accounts";
            labelRowsCountAllSubscriberAccount.Text = Convert.ToString(dataGridViewAllAccounts.RowCount - 1);
        }

        private void buttonSearchAllAccount_Click(object sender, EventArgs e)
        {
            dataGridViewAllAccounts.DataSource = oo.myAccount(textBoxSearchAllAccount.Text);
            dataGridViewAllAccounts.DataMember = "AllAccount";
            labelHeaderTitle.Text = "All Accounts";
            labelRowsCountAllSubscriberAccount.Text = Convert.ToString(dataGridViewAllAccounts.RowCount - 1);
        }

        private void toolStripButtonSaveAccount_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(aItemRegisterCountTextBox.Text);
            try
            {


                if (string.IsNullOrWhiteSpace(accountNameTextBox.Text))
                {

                    MessageBox.Show("Account Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(aAddressTextBox.Text))
                {

                    MessageBox.Show("Address is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(aMobilePhoneTextBox.Text))
                {

                    MessageBox.Show("Mobile Phone is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (aItemRegisterCountTextBox.Text=="0")
                {

                    MessageBox.Show("register Item must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool val = oo.insertUpdatemyAccount(accountNoTextBox.Text, accountNameTextBox.Text, aAddressTextBox.Text, aMobilePhoneTextBox.Text, aHousePhoneTextBox.Text, aOfficePhoneTextBox.Text, aEmailTextBox.Text, log, aStatusTextBox.Text, count, sMSAlertMsgTextBox.Text);
                if (val==true)
                {
                    MessageBox.Show("save success!!");
                }
                else
                {
                    MessageBox.Show("save failed!!");
                }
            }catch(Exception v)
            {
                MessageBox.Show("save failed!!" + v.ToString());
            }
        }

        private void buttonAddNewAccount_Click(object sender, EventArgs e)
        {
            
            tabControl1.SelectedTab = tabPageAllSubscriberAccount;
           
        
        
        
        
        }

        private void dataGridViewAllAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = dataGridViewAllAccounts.Rows[e.RowIndex].Index.ToString();
            string cellValue = dataGridViewAllAccounts.Rows[e.RowIndex].Cells[1].Value.ToString();
            string username = dataGridViewAllAccounts.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxAssignedUser.Text = username;
            loadAccountByAccountNo(cellValue);
            tabControl1.SelectedTab = tabPageAllSubscriberAccount;
            labelHeaderTitle.Text = "Create/Edit Account";
            reloadTrackingItem();
            loadResponderAlertbyAccNo();

            //MessageBox.Show("The row index = " + dataIndexNo.ToString() + " and the row data in second column is: "
            //    + cellValue.ToString());



        }











        ///load account by accountNo
        public void loadAccountByAccountNo(string AccNo)
        {
           
            FormDB con = new FormDB();
            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Account_LoadByAccNo";
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccNo);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {
                           
                            accountNoTextBox.Text = result.GetString(1).ToString();

                            accountNameTextBox.Text= result.GetString(2).ToString();
                            aAddressTextBox.Text= result.GetString(3).ToString();
                            aMobilePhoneTextBox.Text= result.GetString(4).ToString();
                            aHousePhoneTextBox.Text= result.GetString(5).ToString();
                            aOfficePhoneTextBox.Text= result.GetString(6).ToString();
                            aEmailTextBox.Text= result.GetString(7).ToString();
                            textBoxAccountCreatedBy.Text= result.GetString(8).ToString();                         
                             aCreateddateTextBox.Text = result.GetDateTime(9).ToString();
                            aStatusTextBox.Text= result.GetString(10).ToString();
                            aItemRegisterCountTextBox.Text= result.GetInt32(11).ToString();
                            sMSAlertMsgTextBox.Text = result.GetString(12).ToString();
                          
                        }

                    }

                    catch (Exception ex)
                    {


                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }
            }


           
           
           
        }
        public void loadGPSUserByAccountNo(string AccNo,string userName)
        {
           // textBoxAssignedUser.Text = userName;
            //if (AccNo != "C01") { 

            FormDB con = new FormDB();
            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Get_UserByAccNo";
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccNo);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {

                            textBoxAssignedUser.Text = result.GetString(1).ToString();




                        }

                    }

                    catch (Exception ex)
                    {


                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }
            //}
            //else
            //{
            //    textBoxAssignedUser.Text = userName;

            //}


        }
        private void buttonCallAddNewTrackingItem_Click(object sender, EventArgs e)
        {
            FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            ad.accountNoTextBox1.Text = accountNoTextBox.Text;
            ad.checkBoxEditDeviceID.Visible = false;
            ad.checkBoxEditTrackID.Visible = false;
            ad.buttonEditTrackingItem.Visible = false;
            ad.Show();
        }

        private void buttonReloadTrackingItem_Click(object sender, EventArgs e)
        {
            TrackingItemUnderThisAccountDataGridView.DataSource = oo.TrackingItembyAccNo(accountNoTextBox.Text);
            TrackingItemUnderThisAccountDataGridView.DataMember = "TrackingItembyAccNo";
          //  labelHeaderTitle.Text = "All Accounts";
        }


        public void reloadTrackingItem()
        {
            TrackingItemUnderThisAccountDataGridView.DataSource = oo.TrackingItembyAccNo(accountNoTextBox.Text);
            TrackingItemUnderThisAccountDataGridView.DataMember = "TrackingItembyAccNo";
            //buttonReloadTrackingItem.PerformClick();
        }

        private void TrackingItemUnderThisAccountDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            var dataIndexNo = TrackingItemUnderThisAccountDataGridView.Rows[e.RowIndex].Index.ToString();
            string cellValue = TrackingItemUnderThisAccountDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            loadTrackingItemByTrackID(cellValue);
           
        }
        public void loadTrackingItemByTrackID(string TrackID)
        {

           // MessageBox.Show(TrackID);
            FormDB con = new FormDB();
            FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Get_TrackingItemByTrackId";
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {

                            ad.accountNoTextBox1.Text = result.GetString(4).ToString();

                            ad.trackIDTextBox.Text = result.GetString(1).ToString();

                            ad.deviceIDTextBox.Text = result.GetString(2).ToString();

                            ad.trackItemTextBox.Text = result.GetString(0).ToString();

                            ad.gPSModelTextBox.Text = result.GetString(6).ToString();

                            ad.sexTextBox.Text = result.GetString(16).ToString();

                            ad.riskTextBox.Text = result.GetString(17).ToString();

                            ad.ageTextBox.Text = result.GetString(18).ToString();

                            ad.textBoxStatus.Text = result.GetString(13).ToString();
                            ad.textBoxTrackItemID.Text = result.GetInt32(7).ToString();
                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

         
            ad.checkBoxEditDeviceID.Visible = true;
            ad.checkBoxEditTrackID.Visible = true;
            ad.buttonEditTrackingItem.Visible = true;
            ad.buttonSaveAddNewItem.Visible = false;
            ad.trackIDTextBox.Enabled = false;
            ad.deviceIDTextBox.Enabled = false;
            ad.Show();
        }

        private void buttonAddNewResponderAlert_Click(object sender, EventArgs e)
        {
            int countRows = AlertResponderunderThisAccountdataGridView.Rows.Count;

            if (countRows >4)
            {
                MessageBox.Show("Maximum 4 responder only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int i = 0; i < 4;i++ )
            { 
                oo.inserDefaultResponderAlert(accountNoTextBox.Text, "ResponderName " + i.ToString(), "ResponderRelationShip", "Responder Mobile Phone" + i.ToString(), "Responder Email", "Active", log);
            }



            loadResponderAlertbyAccNo();

            
        }


        public void loadResponderAlertbyAccNo()
        {
            AlertResponderunderThisAccountdataGridView.DataSource = oo.ResponderAlertbyAccNo(accountNoTextBox.Text);
            AlertResponderunderThisAccountdataGridView.DataMember = "ResponderAlertbyAccNo";

        }

        private void AlertResponderunderThisAccountdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = AlertResponderunderThisAccountdataGridView.Rows[e.RowIndex].Index.ToString();
            int  cellValue = Convert.ToInt32(AlertResponderunderThisAccountdataGridView.Rows[e.RowIndex].Cells[0].Value);
            loadReaponderAlertByID(cellValue);
        }



        public void loadReaponderAlertByID(int ID)
        {

            // MessageBox.Show(TrackID);
            FormDB con = new FormDB();
            //FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            FormAddNewResponderAlert RA = new FormAddNewResponderAlert();
            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Get_ResponderAlertbyID";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {
                            RA.ResponderIDtxtBox.Text = result.GetInt32(0).ToString();
                            RA.textBoxAccountNo.Text = result.GetString(1).ToString();
                            RA.textBoxResponderName.Text = result.GetString(2).ToString();
                            RA.textBoxRelationShip.Text = result.GetString(3).ToString();
                            RA.textBoxMobilePhone.Text = result.GetString(4).ToString();
                            RA.textBoxEmail.Text = result.GetString(5).ToString();
                            RA.textBoxStatus.Text = result.GetString(6).ToString();
                          

                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            RA.Show();
        }

        private void buttonReloadAlertResponder_Click(object sender, EventArgs e)
        {
            loadResponderAlertbyAccNo();
        }

        private void buttonLoadAllTrackingItem_Click(object sender, EventArgs e)
        {
            trackingItemsDataGridView.DataSource = oo.TrackingItemAll();
            trackingItemsDataGridView.DataMember = "TrackingItemAll";
            labelRowsCountAllTrackingItems.Text = Convert.ToString(trackingItemsDataGridView.RowCount - 1);
        }

        private void buttonSearchTrackingItem_Click(object sender, EventArgs e)
        {
            trackingItemsDataGridView.DataSource = oo.TrackingItemBySearchCol(textBoxSearchTrackingItem.Text);
            trackingItemsDataGridView.DataMember = "TrackingItemBySearchCol";
            labelRowsCountAllTrackingItems.Text = Convert.ToString(trackingItemsDataGridView.RowCount - 1);
        }

        private void trackingItemsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = trackingItemsDataGridView.Rows[e.RowIndex].Index.ToString();
            string cellValue = trackingItemsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (cellValue=="C01")
            {
                MessageBox.Show("This Is a demo Account,.Cannot Access account info from here,,Please Create an account number for this user to enable accessed account info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            { 
            loadAccountByAccountNo(cellValue);
            tabControl1.SelectedTab = tabPageAllSubscriberAccount;
            labelHeaderTitle.Text = "Edit Account";
            reloadTrackingItem();
            loadResponderAlertbyAccNo();
            loadGPSUserByAccountNo(cellValue, "Null");
            }
        }

        private void buttonLoadAllGPSDevices_Click(object sender, EventArgs e)
        {

            trackerDeviceDataGridView.DataSource = oo.GPSDevicesAll();
            trackerDeviceDataGridView.DataMember = "GPSDevicesAll";
            labelRowsCountAllGpsDevice.Text = Convert.ToString(trackerDeviceDataGridView.RowCount - 1);
        }

        private void buttonSearchGPSDevices_Click(object sender, EventArgs e)
        {
            trackerDeviceDataGridView.DataSource = oo.GPSDevicesSearchCol(textBoxGPSDeviceSearch.Text);
            trackerDeviceDataGridView.DataMember = "GPSDevicesSearchCol";
            labelRowsCountAllGpsDevice.Text = Convert.ToString(trackerDeviceDataGridView.RowCount - 1);
        }




        public void loadGPSDeviceByID(int ID)
        {

            // MessageBox.Show(TrackID);
            FormDB con = new FormDB();
            //FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            FormGPSDevices GPSF = new FormGPSDevices();
           
            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Get_TrackerDeviceByID";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {

                            GPSF.iDTextBox1.Text = result.GetInt32(0).ToString();
                            GPSF.deviceIDTextBox1.Text = result.GetString(1).ToString();
                            GPSF.deviceNameTextBox.Text = result.GetString(2).ToString();
                            GPSF.deviceModelTextBox.Text = result.GetString(3).ToString();
                            GPSF.simNumTextBox.Text = result.GetString(8).ToString();
                            GPSF.simOperatorTextBox.Text = result.GetString(9).ToString();
                            GPSF.statusTextBox1.Text = result.GetString(10).ToString();
                            GPSF.createdByTextBox1.Text = result.GetString(11).ToString();
                            GPSF.textBoxCreatedGPSDevice.Text = result.GetDateTime(12).ToString();
                            GPSF.intervalTextBox1.Text = result.GetString(19).ToString();
                            GPSF.gPSserverPortTextBox.Text = result.GetString(23).ToString();
                            GPSF.serverIPTextBox.Text = result.GetString(24).ToString();

                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }
            GPSF.checkBoxEditDeviceID.Visible = true;
            GPSF.buttonSaveGpsDevice.Visible = true;
            GPSF.button1.Visible = false;
            GPSF.Show();
        }

        private void trackerDeviceDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = trackerDeviceDataGridView.Rows[e.RowIndex].Index.ToString();
            int cellValue = Convert.ToInt32(trackerDeviceDataGridView.Rows[e.RowIndex].Cells[0].Value);
            loadGPSDeviceByID(cellValue);
        }

        private void buttonAddNewGPSDevices_Click(object sender, EventArgs e)
        {
            FormGPSDevices GPSF = new FormGPSDevices();
            GPSF.iDTextBox1.Text = "";
            GPSF.deviceIDTextBox1.Text = "";
            GPSF.deviceNameTextBox.Text = "";
            GPSF.deviceModelTextBox.Text = "";
            GPSF.simNumTextBox.Text = "";
            GPSF.simOperatorTextBox.Text = "";
            GPSF.statusTextBox1.Text = "Active";
            GPSF.createdByTextBox1.Text = log;
            GPSF.textBoxCreatedGPSDevice.Text = DateTime.Now.ToLongTimeString();
            GPSF.intervalTextBox1.Text = "";
            GPSF.gPSserverPortTextBox.Text = "";
            GPSF.serverIPTextBox.Text = "";
            GPSF.deviceIDTextBox1.Enabled = true;
            GPSF.checkBoxEditDeviceID.Visible = false;
            GPSF.buttonSaveGpsDevice.Visible = false;
            GPSF.button1.Visible = true;
            GPSF.Show();

        }

        private void buttonRefreshGPSDevices_Click(object sender, EventArgs e)
        {

            trackerDeviceDataGridView.DataSource = oo.GPSDevicesAll();
            trackerDeviceDataGridView.DataMember = "GPSDevicesAll";
            labelRowsCountAllGpsDevice.Text = Convert.ToString(trackerDeviceDataGridView.RowCount - 1);
        }

        private void buttonLoadAllUser_Click(object sender, EventArgs e)
        {

            gPSuserDataGridView.DataSource = oo.GPSUserAll();
            gPSuserDataGridView.DataMember = "GPSUserAll";
            labelRowsCountAllUser.Text = Convert.ToString(gPSuserDataGridView.RowCount - 1);
        }

        private void buttonSearchAllUser_Click(object sender, EventArgs e)
        {
            gPSuserDataGridView.DataSource = oo.GPSUserAllSearchCol(textBoxAllUserSearch.Text);
            gPSuserDataGridView.DataMember = "GPSUserAllSearchCol";
            labelRowsCountAllUser.Text = Convert.ToString(gPSuserDataGridView.RowCount - 1);
        }

        private void buttonRefreshAllUser_Click(object sender, EventArgs e)
        {
            gPSuserDataGridView.DataSource = oo.GPSUserAll();
            gPSuserDataGridView.DataMember = "GPSUserAll";
            labelRowsCountAllUser.Text = Convert.ToString(gPSuserDataGridView.RowCount - 1);
        }

        private void gPSuserDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = gPSuserDataGridView.Rows[e.RowIndex].Index.ToString();
            int cellValue = Convert.ToInt32(gPSuserDataGridView.Rows[e.RowIndex].Cells[0].Value);
            string UserName = gPSuserDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            string AccountNo = gPSuserDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            if(AccountNo=="C01")
            {
                CreateAccountForUser(UserName);
            }else
            {
                loadGPSUserByID(cellValue);
            }

          //  CreateAccountForUser
            
        }

        public void loadGPSUserByID(int ID)
        {

            // MessageBox.Show(TrackID);
            FormDB con = new FormDB();
            //FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            //FormGPSDevices GPSF = new FormGPSDevices();
            FormUser us = new FormUser();

            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Get_GPSUserByID";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {

                            us.iDTextBox3.Text = result.GetInt32(0).ToString();
                            us.userNameTextBox.Text = result.GetString(1).ToString();
                            us.passwordTextBox.Text = result.GetString(2).ToString();
                            us.statusTextBox3.Text = result.GetString(3).ToString();
                            us.accountNoTextBox3.Text = result.GetString(4).ToString();
                            us.registerByTextBox.Text = result.GetString(5).ToString();
                            us.updateByTextBox.Text = result.GetString(6).ToString();
                            us.CreatedDatetextBox.Text = result.GetDateTime(7).ToString();
                          
                           
                            us.loginIPTextBox.Text = result.GetString(10).ToString();
                            us.loginTypeTextBox.Text = result.GetString(11).ToString();
                            string lastlogindate = result.GetDateTime(12).ToString();
                           
                           
                            us.loginCountTextBox.Text = result.GetInt32(13).ToString();
                            us.browserTextBox.Text = result.GetString(15).ToString();
                            us.oSTextBox.Text = result.GetString(16).ToString();
                            us.emailRegTextBox.Text = result.GetString(17).ToString();
                            string modifieddate = result.GetDateTime(8).ToString();
                            if (lastlogindate.Length > 2)
                            { us.LastLoginDatetextBox.Text = result.GetDateTime(12).ToString(); }
                            if (modifieddate.Length > 2)
                            {
                                us.ModifiedDatetextBox.Text = result.GetDateTime(8).ToString();
                            }
                        }

                    }

                    catch (Exception ex)
                    {

                      MessageBox.Show(ex.ToString());
                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }
            //GPSF.checkBoxEditDeviceID.Visible = true;
            //GPSF.buttonSaveGpsDevice.Visible = true;
            //GPSF.button1.Visible = false;
            us.accountNoTextBox3.Enabled = false;
            us.Show();
        }

        private void buttonUserList_Click(object sender, EventArgs e)
        {
            FormUserList Ul = new FormUserList();
            FormUser Us = new FormUser();
            Us.accountNoTextBox3.Enabled = false;
            Ul.textBoxAssignedAccNo.Text = accountNoTextBox.Text;
            Ul.Show();

        }

        private void buttonSaveMyAccount_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(aItemRegisterCountTextBox.Text);
            try
            {

                if (aItemRegisterCountTextBox.Text == "0")
                {
                    aItemRegisterCountTextBox .Text= "0";
                }
                    

                if (string.IsNullOrWhiteSpace(textBoxAssignedUser.Text))
                {

                    MessageBox.Show("Warning!!!,,This Account has no Assigned User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

                if (string.IsNullOrWhiteSpace(accountNameTextBox.Text))
                {

                    MessageBox.Show("Account Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(aAddressTextBox.Text))
                {

                    MessageBox.Show("Address is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(aMobilePhoneTextBox.Text))
                {

                    MessageBox.Show("Mobile Phone is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (aItemRegisterCountTextBox.Text == "0")
                {

                    MessageBox.Show("register Item must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //string checkDupUserName = oo.checkMultipleUserName(textBoxAssignedUser.Text, accountNoTextBox.Text);
                //if (checkDupUserName != "0")
                //{
                //    MessageBox.Show("Assigned User not valid..!!,Assigned User registed in multiple Account !!,it's only valid in one account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
              //  textBoxAssignedUser



                bool val = oo.insertUpdatemyAccount(accountNoTextBox.Text, accountNameTextBox.Text, aAddressTextBox.Text, aMobilePhoneTextBox.Text, aHousePhoneTextBox.Text, aOfficePhoneTextBox.Text, aEmailTextBox.Text, log, aStatusTextBox.Text, count, sMSAlertMsgTextBox.Text);
                if (val == true)
                {
                    MessageBox.Show("save success!!");
                    oo.UpdateUserByUserName(textBoxAssignedUser.Text, accountNoTextBox.Text);
                }
                else
                {
                    MessageBox.Show("save failed!!");
                }
            }
            catch (Exception v)
            {
                MessageBox.Show("save failed!!" + v.ToString());
            }
        }

        private void toolStripButtonTrackingItem_Click(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
            tabControl1.SelectedTab = tabPageAllTrackingItems;
            labelHeaderTitle.Text = "All Tracking Items";      
            trackingItemsDataGridView.DataSource = oo.TrackingItemAll();
            trackingItemsDataGridView.DataMember = "TrackingItemAll";
            labelRowsCountAllTrackingItems.Text = Convert.ToString(trackingItemsDataGridView.RowCount - 1);
        }

        private void toolStripButtonSubscriberGPSDeviceInfo_Click(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
            tabControl1.SelectedTab = tabPageAllGPSDeviceInfo;
            labelHeaderTitle.Text = "All GPS Devices";
            ReloadGpsTrackerDevicelist();
        }

        private void toolStripButtonAllUser_Click(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
            tabControl1.SelectedTab = tabPageUser;
            labelHeaderTitle.Text = "All User";
            ReloadUserList();
        }

        private void buttonSaveEditAccount_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(aItemRegisterCountTextBox.Text);
            try
            {

                if (aItemRegisterCountTextBox.Text == "0")
                {
                    aItemRegisterCountTextBox.Text = "0";
                }


                if (string.IsNullOrWhiteSpace(textBoxAssignedUser.Text))
                {

                    MessageBox.Show("Warning!!!,,This Account has no Assigned User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (!string.IsNullOrWhiteSpace(textBoxAssignedUser.Text))
                {

                    MessageBox.Show("Warning!!!,,This Account has no Assigned User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (string.IsNullOrWhiteSpace(accountNameTextBox.Text))
                {

                    MessageBox.Show("Account Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(aAddressTextBox.Text))
                {

                    MessageBox.Show("Address is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(aMobilePhoneTextBox.Text))
                {

                    MessageBox.Show("Mobile Phone is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (aItemRegisterCountTextBox.Text == "0")
                {

                    MessageBox.Show("register Item must be > 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                
                

                //  textBoxAssignedUser



                bool val = oo.insertUpdatemyAccount(accountNoTextBox.Text, accountNameTextBox.Text, aAddressTextBox.Text, aMobilePhoneTextBox.Text, aHousePhoneTextBox.Text, aOfficePhoneTextBox.Text, aEmailTextBox.Text, log, aStatusTextBox.Text, count, sMSAlertMsgTextBox.Text);
                if (val == true)
                {
                    MessageBox.Show("save success!!");
                }
                else
                {
                    MessageBox.Show("save failed!!");
                }
            }
            catch (Exception v)
            {
                MessageBox.Show("save failed!!" + v.ToString());
            }
        }

        private void panelMainSubScriber_Paint(object sender, PaintEventArgs e)
        {

        }

        public void CreateAccountForUser(string UserName)
        {
            tabControl1.SelectedTab = tabPageAllSubscriberAccount;
            labelHeaderTitle.Text = "Create New Account";
            textBoxAssignedUser.Text = UserName;
            int AccNos = oo.CreateAccountNo();
            accIDTextBox.Text = (AccNos - 1).ToString();
            accountNoTextBox.Text = AccNos.ToString() + "-" + log.Substring(0, 3) + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString(); 
            accountNameTextBox.Text = "";
            aAddressTextBox.Text = "";
            aMobilePhoneTextBox.Text = "";
            aHousePhoneTextBox.Text = "";
            aOfficePhoneTextBox.Text = "";
            aEmailTextBox.Text = "";
            textBoxAccountCreatedBy.Text = log;
            aCreateddateTextBox.Text = DateTime.Now.ToLongDateString();
            aStatusTextBox.Text = "Active";
            aItemRegisterCountTextBox.Text = "0";
            sMSAlertMsgTextBox.Text = "Out of fence detetced!!Please login to->tarmizi-003-site3.atempurl.com Virtual Fence Alert Agensi Angkasa Negara-Malaysia";
        
        
        }




        public void ReloadAllAccList()
        {
            dataGridViewAllAccounts.DataSource = oo.myAccount("LoadAllAccount");
            dataGridViewAllAccounts.DataMember = "AllAccount";
            labelRowsCountAllSubscriberAccount.Text = Convert.ToString(dataGridViewAllAccounts.RowCount - 1);
            //labelRowsCountAllTrackingItems.Text = Convert.ToString(trackingItemsDataGridView.RowCount - 1);
        }
        public void ReloadUserList()
        {
            gPSuserDataGridView.DataSource = oo.GPSUserAll();
            gPSuserDataGridView.DataMember = "GPSUserAll";

            labelRowsCountAllUser.Text = Convert.ToString(gPSuserDataGridView.RowCount - 1);
        }
        public void ReloadTrackingItemList()
        {
            TrackingItemUnderThisAccountDataGridView.DataSource = oo.TrackingItembyAccNo(accountNoTextBox.Text);
            TrackingItemUnderThisAccountDataGridView.DataMember = "TrackingItembyAccNo";
        }

        public void ReloadAllTrackingItemList()
        {
            trackingItemsDataGridView.DataSource = oo.TrackingItemAll();
            trackingItemsDataGridView.DataMember = "TrackingItemAll";
            labelRowsCountAllTrackingItems.Text = Convert.ToString(trackingItemsDataGridView.RowCount - 1);
        }

        public void ReloadGpsTrackerDevicelist()
        {
            trackerDeviceDataGridView.DataSource = oo.GPSDevicesAll();
            trackerDeviceDataGridView.DataMember = "GPSDevicesAll";
            labelRowsCountAllGpsDevice.Text = Convert.ToString(trackerDeviceDataGridView.RowCount - 1);
        }

        private void checkBoxActiveInActiveAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActiveInActiveAccount.Checked == true)
            {
                aStatusTextBox.Text = "Active";
            }
            else
            {
                aStatusTextBox.Text = "InActive";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxSearchTrackingItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
