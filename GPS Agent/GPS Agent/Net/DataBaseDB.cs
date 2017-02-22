using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GPSAgent.Net
{
    class DataBaseDB
    {
        private  double DecMinsToDegrees(double dValue)
        {
            return Convert.ToInt32(dValue / 100) + (dValue - (Convert.ToInt32(dValue / 100) * 100)) / 60;
        }

        //public void insertGPSdata(string DeviceID,string IMEI_no,string SignalStatus,string Password,string DataType,
        //    string PacketNumber,string GSMBaseSt,string Longitude,string Latitude,string Speed,string Direction,
        //    string DateS,DateTime DateD,DateTime DT,string SignalINs,DateTime SignalINd,string TrackID,
        //    string GPSSimNumber,string BatteryReading)

        public void insertGPSdata(string DeviceID, string IMEI_no, string SignalStatus, string Password, string DataType,
        string PacketNumber, string GSMBaseSt, string Longitude, string Latitude, string Speed, string Direction,
        string TrackID,
        string GPSSimNumber, string BatteryReading)
        {
            double y= Convert.ToDouble(Latitude);
            double x = Convert.ToDouble(Longitude);
            double lat = DecMinsToDegrees(y);
            double longi = DecMinsToDegrees(x);
            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
            String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
            SqlConnection _SQLConnection = new SqlConnection(connectionString);
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
                        _SQLCommand.Parameters.AddWithValue("@Longitude", longi.ToString());
                        _SQLCommand.Parameters.AddWithValue("@Latitude", lat.ToString());
                        _SQLCommand.Parameters.AddWithValue("@Speed", Speed);
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
    }
}