using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public static class clsApplications_Data
    {

        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * From Applications 
                       Where ApplicationID = @ApplicationID; ";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


            bool isFuond = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    isFuond = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFuond = false;

                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();

            }

            return isFuond;
        }


        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                                              byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);


            string query = @"
                             INSERT INTO Applications 
                             (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, 
                              LastStatusDate, PaidFees, CreatedByUserID)
                             VALUES
                             (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, 
                              @LastStatusDate, @PaidFees, @CreatedByUserID);
                            
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            int NewApplactionID = -1;
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewApplactionID = InsertedID;
                }
            }
            catch (Exception ex)
            {

                NewApplactionID = -1;
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return NewApplactionID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID,
                                    DateTime ApplicationDate, int ApplicationTypeID,
                                    byte ApplicationStatus, DateTime LastStatusDate,
                                    float PaidFees, int CreatedByUserID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);


            string query = @"
                              UPDATE Applications
                              SET 
                                  ApplicantPersonID = @ApplicantPersonID,
                                  ApplicationDate = @ApplicationDate,
                                  ApplicationTypeID = @ApplicationTypeID,
                                  ApplicationStatus = @ApplicationStatus,
                                  LastStatusDate = @LastStatusDate,
                                  PaidFees = @PaidFees,
                                  CreatedByUserID = @CreatedByUserID
                              WHERE ApplicationID = @ApplicationID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            int AffectedRows = 0;
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"DELETE FROM Applications 
                     WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            int AffectedRows = 0;

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }
        public static DataTable GetAllApplications()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT *
                                      FROM Applications; ";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtApplications = new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtApplications.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return dtApplications;
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select isFound=1  
                               From Applications Where ApplicationID =@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }
            catch (Exception)
            {


            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            //in case the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT ActiveApplicationID=ApplicationID
                                   FROM Applications
                                       WHERE ApplicantPersonID = @ApplicantPersonID 
                                         and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {

                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return ActiveApplicationID;

            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }


        public static bool UpdateStatus(int ApplicationID, byte NewStatus)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Update Applications 
                                         SET 
                                            ApplicationStatus = @NewStatus,
                                            LastStatusDate = @LastStatusDate
                                        Where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);

            int rowEffected = 0;
            try
            {
                connection.Open();
                rowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowEffected > 0);

        }
    }
}
