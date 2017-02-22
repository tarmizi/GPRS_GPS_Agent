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
using GPSAgent.Components.Form;
namespace GPSAgent
{
    class DB
    {

        private string _TrackID;
        private string _SimNum;
        private string connstring;


        public string TrackingID
        {
            get
            {
                return _TrackID;
            }
            set
            {
                _TrackID = value;
            }
        }
        public string SimNumber
        {
            get
            {
                return _SimNum;
            }
            set
            {
                _SimNum = value;
            }
        }

        private static double KnotsToKMPerSecond(double dValue)
        {
           // return dValue * 0.514444d;

            return dValue * 1.85;
        }
      

        private double DecMinsToDegrees(string dValue)
        {
           //return Convert.ToInt32(dValue / 100) + (dValue - (Convert.ToInt32(dValue / 100) * 100)) / 60;



            string latlong = dValue;
            int latlongleng = latlong.Length;
            int index = latlong.IndexOf('.');
            string sv = latlong.Substring(index - 2, 7);
            int svleng = sv.Length;
            int lengresult = latlongleng - svleng;
            string latlonghead = latlong.Substring(0, lengresult);

            double resultlatlong = (Convert.ToDouble(sv) / 60) + Convert.ToInt32(latlonghead);







            //string latlong = Convert.ToString(dValue); 
            //int latlongleng = latlong.Length;
            //int index = latlong.IndexOf('.');
            //double sv = Convert.ToDouble(latlong.Substring(index - 2, 7));
            //int svleng = sv.ToString().Length;
            //int lengresult = latlongleng - svleng;
            //string latlonghead = latlong.Substring(0, lengresult);

//0255.6290 N
//10139.0953 E


//Lat : 12° 49.9265' = 12° + 49.9265/60 = 12.832108°
//Lon : 38° 16.1698' = 38° + 16.1698/60 = 38.269497°

//02.92715,101.6515883333333333


          //  double lat = Convert.ToDouble(dValue);
           // int rLat = Convert.ToInt32(dValue / 100);
           //int rrlat = Convert.ToInt32(100 * rLat);
           //double rrrlat = dValue - rrlat;
           //double output = Math.Round(rrrlat, 3);
           //double dec = rLat + (output / 60);

            return resultlatlong;




            //double degminsec = dValue;
            // decimal seconds
            //double decsec = (degminsec * 100 - Math.Truncate(degminsec * 100)) / .6;
            //degrees and minutes
            //double degmin = (Math.Truncate(degminsec * 100) + decsec) / 100;
            //degrees
            //double deg = Math.Truncate(degmin);
            //decimal degrees
            //double decdeg = deg + (degmin - deg) / .6;

            //return decdeg;
        }
       // string procesedDeviceID;
        //public void insertGPSdata(string DeviceID,string IMEI_no,string SignalStatus,string Password,string DataType,
        //    string PacketNumber,string GSMBaseSt,string Longitude,string Latitude,string Speed,string Direction,
        //    string DateS,DateTime DateD,DateTime DT,string SignalINs,DateTime SignalINd,string TrackID,
        //    string GPSSimNumber,string BatteryReading)

        public void insertGPSdata(string DeviceID, string IMEI_no, string SignalStatus, string Password, string DataType,
        string PacketNumber, string GSMBaseSt, string Longitude, string Latitude, string Speed, string Direction,
        string TrackID,
        string GPSSimNumber, string BatteryReading,int Altitude,int GSMSignalReading,string TerminalState,string APN)
        {
            FormDB con=new FormDB();
           // double y = Convert.ToDouble(Latitude);
           // double x = Convert.ToDouble(Longitude);
          
            //comment for MSI project
            //double lat = DecMinsToDegrees(Latitude);
            //double longi = DecMinsToDegrees(Longitude);

            double kelajuan =  KnotsToKMPerSecond(Convert.ToDouble(Speed));
            
            connstring = con.connectstring();



            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
           // String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
          //  String connectionString = (connstring);

            SqlConnection _SQLConnection = new SqlConnection(connstring);
           // SqlConnection _SQLConnection = new SqlConnection(connectionString);
            //SqlConnection _SQLConnection = SQLConnectionString.BuildConnection();
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
                        _SQLCommand.CommandText = "GPS_insertdata";
                        _SQLCommand.Parameters.AddWithValue("@DeviceID", DeviceID);
                        _SQLCommand.Parameters.AddWithValue("@IMEI_no", IMEI_no);
                        _SQLCommand.Parameters.AddWithValue("@SignalStatus", SignalStatus);
                        _SQLCommand.Parameters.AddWithValue("@Password", Password);
                        _SQLCommand.Parameters.AddWithValue("@DataType", DataType);
                        _SQLCommand.Parameters.AddWithValue("@PacketNumber", PacketNumber);
                        _SQLCommand.Parameters.AddWithValue("@GSMBaseSt", GSMBaseSt);
                        _SQLCommand.Parameters.AddWithValue("@Longitude", Longitude);
                        _SQLCommand.Parameters.AddWithValue("@Latitude", Latitude);
                        _SQLCommand.Parameters.AddWithValue("@Speed", Math.Round(kelajuan, 2).ToString());
                        _SQLCommand.Parameters.AddWithValue("@Direction", Direction);
                        //_SQLCommand.Parameters.AddWithValue("@DateS", DateS);
                        // _SQLCommand.Parameters.AddWithValue("@DateD", DateD);
                        //_SQLCommand.Parameters.AddWithValue("@DT", DT);
                        // _SQLCommand.Parameters.AddWithValue("@SignalINs", SignalINs);
                        // _SQLCommand.Parameters.AddWithValue("@SignalINd", SignalINd);
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _SQLCommand.Parameters.AddWithValue("@GPSSimNumber", GPSSimNumber);
                        _SQLCommand.Parameters.AddWithValue("@BatteryReading", BatteryReading);


                        _SQLCommand.Parameters.AddWithValue("@Altitude", Altitude);
                        _SQLCommand.Parameters.AddWithValue("@GSMSignalReading", GSMSignalReading);
                        _SQLCommand.Parameters.AddWithValue("@TerminalState", TerminalState);
                        _SQLCommand.Parameters.AddWithValue("@APN", APN);
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {

                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }



        }



        public void insertGPSdataNonMSI(string DeviceID, string IMEI_no, string SignalStatus, string Password, string DataType,
       string PacketNumber, string GSMBaseSt, string Longitude, string Latitude, string Speed, string Direction,
       string TrackID,
       string GPSSimNumber, string BatteryReading)
        {
            FormDB con = new FormDB();
            // double y = Convert.ToDouble(Latitude);
            // double x = Convert.ToDouble(Longitude);

            //comment for MSI project
            double lat = DecMinsToDegrees(Latitude);
            double longi = DecMinsToDegrees(Longitude);

            double kelajuan = KnotsToKMPerSecond(Convert.ToDouble(Speed));

            connstring = con.connectstring();



            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
            // String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
            //  String connectionString = (connstring);

            SqlConnection _SQLConnection = new SqlConnection(connstring);
            // SqlConnection _SQLConnection = new SqlConnection(connectionString);
            //SqlConnection _SQLConnection = SQLConnectionString.BuildConnection();
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
                        _SQLCommand.CommandText = "GPS_insertdata";
                        _SQLCommand.Parameters.AddWithValue("@DeviceID", DeviceID);
                        _SQLCommand.Parameters.AddWithValue("@IMEI_no", IMEI_no);
                        _SQLCommand.Parameters.AddWithValue("@SignalStatus", SignalStatus);
                        _SQLCommand.Parameters.AddWithValue("@Password", Password);
                        _SQLCommand.Parameters.AddWithValue("@DataType", DataType);
                        _SQLCommand.Parameters.AddWithValue("@PacketNumber", PacketNumber);
                        _SQLCommand.Parameters.AddWithValue("@GSMBaseSt", GSMBaseSt);
                       // _SQLCommand.Parameters.AddWithValue("@Longitude", longi.ToString());

                        _SQLCommand.Parameters.AddWithValue("@Longitude", lat.ToString());
                        _SQLCommand.Parameters.AddWithValue("@Latitude", longi.ToString());
                        _SQLCommand.Parameters.AddWithValue("@Speed", Math.Round(kelajuan, 2).ToString());
                        _SQLCommand.Parameters.AddWithValue("@Direction", Direction);
                        //_SQLCommand.Parameters.AddWithValue("@DateS", DateS);
                        // _SQLCommand.Parameters.AddWithValue("@DateD", DateD);
                        //_SQLCommand.Parameters.AddWithValue("@DT", DT);
                        // _SQLCommand.Parameters.AddWithValue("@SignalINs", SignalINs);
                        // _SQLCommand.Parameters.AddWithValue("@SignalINd", SignalINd);
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _SQLCommand.Parameters.AddWithValue("@GPSSimNumber", GPSSimNumber);
                        _SQLCommand.Parameters.AddWithValue("@BatteryReading", BatteryReading);
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {

                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }



        }

        public void deleteAllsignal()
        {
            FormDB con = new FormDB();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            // SqlConnection _SQLConnection = new SqlConnection(connectionString);
            //SqlConnection _SQLConnection = SQLConnectionString.BuildConnection();
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
                        _SQLCommand.CommandText = "GPS_deleteAllsignal";
                      
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {

                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }
        }


        public void GetSimNumTrackID(string DeviceID)
        {


            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            int i = 0;
           // String connectionString = (connstring);
           // connetionString = "Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;";
            connection = new SqlConnection(connstring);

            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_SimNumTrackID";

            param = new SqlParameter("@DeviceID", DeviceID);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                TrackingID = ds.Tables[0].Rows[i][0].ToString();
               SimNumber = ds.Tables[0].Rows[i][1].ToString();
              //  MessageBox.Show(ds.Tables[0].Rows[i][0].ToString() + "," + ds.Tables[0].Rows[i][1].ToString());
            }

            connection.Close();
        }

        #region MyAccount

        public DataSet myAccount(string AccNo)
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Load_AllAccount";

            param = new SqlParameter("@AccountNo", AccNo);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds,"AllAccount");

            return ds;


        }


        public bool insertUpdatemyAccount(string AccountNo, string AccountName, string AAddress, string AMobilePhone, string AHousePhone, string AOfficePhone, string AEmail, string ACreatedBy, string Status, int AItemRegisterCount, string SMSAlertMsg)
        {
            bool val=false;
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
                        _SQLCommand.CommandText = "Account_InsertUpdate";
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@AccountName", AccountName);
                        _SQLCommand.Parameters.AddWithValue("@AAddress", AAddress);
                        _SQLCommand.Parameters.AddWithValue("@AMobilePhone", AMobilePhone);
                        _SQLCommand.Parameters.AddWithValue("@AHousePhone", AHousePhone);
                        _SQLCommand.Parameters.AddWithValue("@AOfficePhone", AOfficePhone);
                        //_SQLCommand.Parameters.AddWithValue("@AAlertPhone", AAlertPhone);
                        _SQLCommand.Parameters.AddWithValue("@AEmail", AEmail);
                        _SQLCommand.Parameters.AddWithValue("@ACreatedBy", ACreatedBy);
                        _SQLCommand.Parameters.AddWithValue("@Status", Status);
                        _SQLCommand.Parameters.AddWithValue("@AItemRegisterCount", AItemRegisterCount);
                        _SQLCommand.Parameters.AddWithValue("@SMSAlertMsg", SMSAlertMsg);
                        
                        
                       
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        val = true;

                    }

                    catch (Exception ex)
                    {
                        val = false;
                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            return val;
        }


        public int CreateAccountNo()
        {

            int val = 0;
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
                        _SQLCommand.CommandText = "Get_AccLatestID";
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {
                            val = result.GetInt32(0);
                            //I assume that both fields are string, for Int you can use GetInt32
                            // the values of '0' and '1' inside ( ) are the index of the strings in the row
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

            return val;
        }


        #endregion

        #region TrackingItem


        public string checkMultipleTrackID(string TrackID)
        {
            string Checkresult = "0";

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
                        _SQLCommand.CommandText = "TrackingItem_CheckDupTrackingID";
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();                        result.Read();
                        if (result.HasRows)
                        {

                            Checkresult = result.GetInt32(0).ToString();

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





            return Checkresult;


        }
        public string checkMultipleDeviceID(string TrackID, string DeviceID)
        {
            string Checkresult = "0";

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
                        _SQLCommand.CommandText = "TrackingItem_CheckDupDeviceIDinMyAccount";
                        _SQLCommand.Parameters.AddWithValue("@DeviceID", DeviceID);
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader(); result.Read();
                        if (result.HasRows)
                        {

                            Checkresult = result.GetInt32(0).ToString();

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





            return Checkresult;


        }

        public bool insertUpdateTrackingItem(string AccountNo, string TrackID,
            string DeviceID, string TrackItem, string GPSModel, string CreatedBy,
            string ModifiedBy, string Status, string Sex, string Risk,string Age,int ID)
        {
            bool val = false;
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
                        _SQLCommand.CommandText = "TrackingItem_InsertUpdateAdmin";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _SQLCommand.Parameters.AddWithValue("@DeviceID", DeviceID);
                        _SQLCommand.Parameters.AddWithValue("@TrackItemType", "Human");
                        _SQLCommand.Parameters.AddWithValue("@TrackItem", TrackItem);
                        _SQLCommand.Parameters.AddWithValue("@GPSModel", GPSModel);
                        _SQLCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                        _SQLCommand.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
                        _SQLCommand.Parameters.AddWithValue("@TrackingMode", "Standard");
                        _SQLCommand.Parameters.AddWithValue("@Status", Status);
                        _SQLCommand.Parameters.AddWithValue("@Term", 1);
                        _SQLCommand.Parameters.AddWithValue("@Sex", Sex);
                        _SQLCommand.Parameters.AddWithValue("@Risk", Risk);
                        _SQLCommand.Parameters.AddWithValue("@Age", Age);


                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        val = true;

                    }

                    catch (Exception ex)
                    {
                        val = false;
                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            return val;
        }



        public DataSet TrackingItembyAccNo(string AccNo)
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_TrackingItem";

            param = new SqlParameter("@AccountNo", AccNo);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "TrackingItembyAccNo");

            return ds;


        }



        public DataSet TrackingItemAll()
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
          //  SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_TrackingItemAll";

            //param = new SqlParameter("@AccountNo", AccNo);
            //param.Direction = ParameterDirection.Input;
            //param.DbType = DbType.String;
            //command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "TrackingItemAll");

            return ds;


        }




        public DataSet TrackingItemBySearchCol(string Search)
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
              SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "TrackingItem_SearchByColSearch";

            param = new SqlParameter("@Search", Search);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "TrackingItemBySearchCol");

            return ds;


        }

        #endregion


        #region responderAlert


        public bool inserDefaultResponderAlert(string AccountNo, string ResponderName,
           string ResponderRelationShip, string ResponderPhoneNo, string ResponderEmail, string Status,
           string User)
        {
            bool val = false;
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
                        _SQLCommand.CommandText = "ResponderAlert_InsertDefault";
                   
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@ResponderName", ResponderName);
                        _SQLCommand.Parameters.AddWithValue("@ResponderRelationShip", ResponderRelationShip);
                        _SQLCommand.Parameters.AddWithValue("@ResponderPhoneNo", ResponderPhoneNo);
                        _SQLCommand.Parameters.AddWithValue("@ResponderEmail", ResponderEmail);
                        _SQLCommand.Parameters.AddWithValue("@Status", Status);
                        _SQLCommand.Parameters.AddWithValue("@User", User);
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        val = true;

                    }

                    catch (Exception ex)
                    {
                        val = false;
                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            return val;
        }



        public DataSet ResponderAlertbyAccNo(string AccNo)
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_ResponderAlertbyAccNo";

            param = new SqlParameter("@AccountNo", AccNo);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "ResponderAlertbyAccNo");

            return ds;


        }





        public bool updateResponderAlert(int ID,string AccountNo, string ResponderName,
          string ResponderRelationShip, string ResponderPhoneNo, string ResponderEmail, string Status,
          string User)
        {
            bool val = false;
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
                        _SQLCommand.CommandText = "ResponderAlert_InsertUpdate";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@ResponderName", ResponderName);
                        _SQLCommand.Parameters.AddWithValue("@ResponderRelationShip", ResponderRelationShip);
                        _SQLCommand.Parameters.AddWithValue("@ResponderPhoneNo", ResponderPhoneNo);
                        _SQLCommand.Parameters.AddWithValue("@ResponderEmail", ResponderEmail);
                        _SQLCommand.Parameters.AddWithValue("@Status", Status);
                        _SQLCommand.Parameters.AddWithValue("@GeofenceStatus", "Null");                        
                        _SQLCommand.Parameters.AddWithValue("@User", User);
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        val = true;

                    }

                    catch (Exception ex)
                    {
                        val = false;
                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            return val;
        }

        #endregion

        #region GPSDevices

        public DataSet GPSDevicesAll()
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            //  SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_TrackerDeviceAll";

            //param = new SqlParameter("@AccountNo", AccNo);
            //param.Direction = ParameterDirection.Input;
            //param.DbType = DbType.String;
            //command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "GPSDevicesAll");

            return ds;


        }


        public DataSet GPSDevicesSearchCol(string Search)
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_TrackerDeviceBySearchCol";

            param = new SqlParameter("@Search", Search);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "GPSDevicesSearchCol");

            return ds;


        }


       

        public bool insertUpdateGPSDevices(int ID, string DeviceID,
         string DeviceName, string DeviceModel, string SimNum, string SimOperator,
         string ServerIP, string GPSserverPort, string Status, string Interval, string CreatedBy)
        {
            bool val = false;
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
                        _SQLCommand.CommandText = "TrackerDevice_InsertUpdate";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _SQLCommand.Parameters.AddWithValue("@DeviceID", DeviceID);
                        _SQLCommand.Parameters.AddWithValue("@DeviceName", DeviceName);
                        _SQLCommand.Parameters.AddWithValue("@DeviceModel", DeviceModel);
                        _SQLCommand.Parameters.AddWithValue("@SimNum", SimNum);
                        _SQLCommand.Parameters.AddWithValue("@SimOperator", SimOperator);
                        _SQLCommand.Parameters.AddWithValue("@ServerIP", ServerIP);
                        _SQLCommand.Parameters.AddWithValue("@GPSserverPort", GPSserverPort);
                        _SQLCommand.Parameters.AddWithValue("@Status", Status);
                        _SQLCommand.Parameters.AddWithValue("@Interval", Interval);
                        _SQLCommand.Parameters.AddWithValue("@CreatedBy", CreatedBy);


                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        val = true;

                    }

                    catch (Exception ex)
                    {
                        val = false;
                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            return val;
        }






        public string checkMultipleDeviceIDGPSDDevice(string DeviceID)
        {
            string Checkresult = "0";

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
                        _SQLCommand.CommandText = "TrackerDevice_CheckDupDeviceID";
                        _SQLCommand.Parameters.AddWithValue("@DeviceID", DeviceID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader(); result.Read();
                        if (result.HasRows)
                        {

                            Checkresult = result.GetInt32(0).ToString();

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





            return Checkresult;


        }
        #endregion


        #region User

        public DataSet GPSUserAll()
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            //  SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_AllGPSUser";

            //param = new SqlParameter("@AccountNo", AccNo);
            //param.Direction = ParameterDirection.Input;
            //param.DbType = DbType.String;
            //command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "GPSUserAll");

            return ds;


        }

        public DataSet GPSUserAllSearchCol(string Search)
        {
            FormDB con = new FormDB();
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            DataSet ds = new DataSet();
            connstring = con.connectstring();
            connection = new SqlConnection(connstring);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_GPSUserBySearchCol";

            param = new SqlParameter("@Search", Search);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "GPSUserAllSearchCol");

            return ds;


        }

        public bool updateGPSUser(int ID, string UserName, string Password,
         string Status, string AccountNo, string UpdateBy, string LoginType,
         string EmailReg)
        {
            bool val = false;
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
                        _SQLCommand.CommandText = "User_Update";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _SQLCommand.Parameters.AddWithValue("@UserName", UserName);
                        _SQLCommand.Parameters.AddWithValue("@Password", Password);
                        _SQLCommand.Parameters.AddWithValue("@Status", Status);
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@UpdateBy", UpdateBy);
                        _SQLCommand.Parameters.AddWithValue("@LoginType", LoginType);
                        _SQLCommand.Parameters.AddWithValue("@EmailReg", EmailReg);                       
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        val = true;

                    }

                    catch (Exception ex)
                    {
                        val = false;
                        // LogAddError(ex);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }

            return val;
        }

        public string checkMultipleUserName(string UserName,string AccountNo)
        {
            string Checkresult = "0";

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
                        _SQLCommand.CommandText = "Get_GPSUserByUserNameCheck";
                        _SQLCommand.Parameters.AddWithValue("@UserName", UserName);
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader(); result.Read();
                        if (result.HasRows)
                        {

                            Checkresult = result.GetInt32(0).ToString();

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





            return Checkresult;


        }


        public void UpdateUserByUserName(string UserName, string AccountNo)
        {
            //string Checkresult = "0";

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
                        _SQLCommand.CommandText = "User_UpdateByUserName";
                        _SQLCommand.Parameters.AddWithValue("@UserName", UserName);
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _DBConnection.Open();
                        _SQLCommand.ExecuteNonQuery();
                        //SqlDataReader result = _SQLCommand.ExecuteReader(); result.Read();
                        //if (result.HasRows)
                        //{

                        //    Checkresult = result.GetInt32(0).ToString();

                        //}

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





           // return Checkresult;


        }

        #endregion
    }

}