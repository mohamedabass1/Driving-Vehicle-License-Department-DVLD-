using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsLicense_Data
    {
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO Licenses 
                        (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, 
                         Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                         
                         VALUES 
                        (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
                         @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);

                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    if (!string.IsNullOrWhiteSpace(Notes))
                        command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            NewLicenseID = InsertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        NewLicenseID = -1;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return NewLicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
             string Notes, float PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE Licenses
                         SET 
                            ApplicationID = @ApplicationID,
                            DriverID = @DriverID,
                            LicenseClass = @LicenseClass,
                            IssueDate = @IssueDate,
                            ExpirationDate = @ExpirationDate,
                            Notes = @Notes,
                            PaidFees = @PaidFees,
                            IsActive = @IsActive,
                            IssueReason = @IssueReason,
                            CreatedByUserID = @CreatedByUserID
                         WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    if (!string.IsNullOrWhiteSpace(Notes))
                        command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static bool GetLicenseByID(int LicenseID,
                                          ref int ApplicationID, ref int DriverID, ref int LicenseClass,
                                          ref DateTime IssueDate, ref DateTime ExpirationDate,
                                          ref string Notes, ref float PaidFees, ref bool IsActive,
                                          ref int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT *
                         FROM Licenses
                         WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";

                                PaidFees = Convert.ToSingle(reader["PaidFees"]);

                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                IssueReason = Convert.ToInt32(reader["IssueReason"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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

        public static bool GetLicenseByDriverIDAndLicenseClass(int DriverID, int LicenseClass,
            ref int LicenseID, ref int ApplicationID,
            ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref string Notes, ref float PaidFees, ref bool IsActive,
            ref int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT LicenseID, ApplicationID, IssueDate, ExpirationDate,
                                Notes, PaidFees, IsActive, IssueReason, CreatedByUserID
                         FROM Licenses
                         WHERE DriverID = @DriverID AND LicenseClass = @LicenseClass;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LicenseID = (int)reader["LicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";

                                PaidFees = Convert.ToSingle(reader["PaidFees"]);

                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (int)reader["IssueReason"];
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


        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                                Notes, PaidFees, IsActive, IssueReason, CreatedByUserID
                         FROM Licenses
                         ORDER BY LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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


        public static bool IsActiveLicense(int LicenseID)
        {
            bool IsActive = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT IsActive FROM Licenses
                         WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            IsActive = (bool)result;
                        }
                    }
                    catch (Exception ex)
                    {
                        IsActive = false;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return IsActive;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE Licenses
                         SET IsActive = 0
                         WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

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


        /// 
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)
        {
            int LicenseID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT Licenses.LicenseID 
                               FROM Licenses 
		                            INNER JOIN Drivers On Drivers.DriverID = Licenses.DriverID
		                      WHERE (Drivers.PersonID = @PersonID) AND (Licenses.LicenseClass =  @LicenseClass) AND (Licenses.IsActive = 1);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LicenseID = (int)result;
                        }
                    }
                    catch (Exception ex)
                    {
                        LicenseID = -1;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }
                }
            }

            return LicenseID;
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                                  FROM  Licenses INNER JOIN
                                                  LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                         Where Licenses.DriverID = @DriverID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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
    }
}
