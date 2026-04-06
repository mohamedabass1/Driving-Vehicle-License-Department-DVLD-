using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsInternationalLicenses_Data
    {
        //int InternationalLicenseID , int ApplicationID ,int DriverID,int IssuedUsingLocalLicenseID, DateTime IssuedDate,DateTime ExpirationDate,bool IsActive, int CreatedByUserID

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int NewInternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Insert Into InternationalLicenses
                                    (ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                             Values( @ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID); 
              SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            NewInternationalLicenseID = InsertedID;
                        }

                    }
                    catch (Exception ex)
                    {
                        NewInternationalLicenseID = -1;

                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }

                }
            }

            return NewInternationalLicenseID;
        }

        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int AffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Update InternationalLicenses
                                                set ApplicationID = @ApplicationID,
                                                    DriverID = @DriverID,
                                                    IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                                                    IssueDate = @IssueDate,
                                                    ExpirationDate = @ExpirationDate,
                                                    IsActive = @IsActive,
                                                    CreatedByUserID = @CreatedByUserID
                                                Where InternationalLicenseID = @InternationalLicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        AffectedRows = command.ExecuteNonQuery();



                    }
                    catch (Exception ex)
                    {
                        AffectedRows = 0;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }

                }
            }

            return (AffectedRows > 0);
        }

        public static bool GetInternationalLicenseByID(int InternationalLicenseID,
                                                       ref int ApplicationID,
                                                       ref int DriverID,
                                                       ref int IssuedUsingLocalLicenseID,
                                                       ref DateTime IssueDate,
                                                       ref DateTime ExpirationDate,
                                                       ref bool IsActive,
                                                       ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM InternationalLicenses
                         WHERE InternationalLicenseID=@InternationalLicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsFound;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Select InternationalLicenseID From InternationalLicenses
                                    Where DriverID = @DriverID and IsActive = 1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                            InternationalLicenseID = Convert.ToInt32(result);


                    }
                    catch (Exception ex)
                    {
                        InternationalLicenseID = -1;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return InternationalLicenseID;
        }
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT  InternationalLicenseID, ApplicationID,DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive
                                FROM    InternationalLicenses
                         Order by InternationalLicenseID DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return dt;
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"                
                                SELECT  InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive
                                   FROM    InternationalLicenses
                                Where DriverID = @DriverID
                                 Order by InternationalLicenseID DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);


                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }


                        }
                    }

                    catch (Exception ex)
                    {
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }


                }
            }
            return dt;
        }

        public static bool DeactivateInternationalLicense(int InternationalLicenseID)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE InternationalLicenses
                         SET IsActive = 0
                         WHERE InternationalLicenseID = @InternationalLicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();
                        AffectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        AffectedRows = 0;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return (AffectedRows > 0);
        }

    }
}
