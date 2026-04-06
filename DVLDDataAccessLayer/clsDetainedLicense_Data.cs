using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsDetainedLicense_Data
    {


        // int DetainID , int LicenseID, DateTime DetainDate,float FineFees, int CreatedByUserID,bool IsReleased, DateTime ReleaseDate,int ReleasedByUserID,int ReleaseApplicationID
        //  DetainID ,  LicenseID,  DetainDate, FineFees,  CreatedByUserID, IsReleased,  ReleaseDate, ReleasedByUserID, ReleaseApplicationID



        public static bool GetDetainedLicenseInfoByID(int DetainID,
                                                      ref int LicenseID, ref DateTime DetainDate,
                                                      ref float FineFees, ref int CreatedByUserID,
                                                      ref bool IsReleased, ref DateTime ReleaseDate,
                                                      ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"];

                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                                    ? DateTime.MaxValue
                                    : (DateTime)reader["ReleaseDate"];

                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                                    ? -1
                                    : (int)reader["ReleasedByUserID"];

                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                                    ? -1
                                    : (int)reader["ReleaseApplicationID"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }
                }
            }

            return isFound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
                                                             ref int DetainID, ref DateTime DetainDate,
                                                             ref float FineFees, ref int CreatedByUserID,
                                                             ref bool IsReleased, ref DateTime ReleaseDate,
                                                             ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT TOP 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID ORDER BY DetainID DESC";

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
                                isFound = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"];

                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                                    ? DateTime.MaxValue
                                    : (DateTime)reader["ReleaseDate"];

                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                                    ? -1
                                    : (int)reader["ReleasedByUserID"];

                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                                    ? -1
                                    : (int)reader["ReleaseApplicationID"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return isFound;
        }


        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees,
                                                int CreatedByUserID)
        {
            int NewDetainID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO DetainedLicenses 
                (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                 
                 VALUES 
                (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);

                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            NewDetainID = InsertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        NewDetainID = -1;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return NewDetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees,
                                                 int CreatedByUserID)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE DetainedLicenses
                 SET 
                    LicenseID = @LicenseID,
                    DetainDate = @DetainDate,
                    FineFees = @FineFees,
                    CreatedByUserID = @CreatedByUserID
                 WHERE DetainID = @DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
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

        public static bool ReleaseDetainedLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE DetainedLicenses
                 SET 
                    IsReleased = 1,
                    ReleaseDate = @ReleaseDate,
                    ReleasedByUserID = @ReleasedByUserID,
                    ReleaseApplicationID = @ReleaseApplicationID
                 WHERE DetainID = @DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses_View ORDER BY IsReleased, DetainID";

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
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT IsDetained = 1 
                         FROM DetainedLicenses 
                         WHERE LicenseID = @LicenseID 
                         AND IsReleased = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsDetained = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return IsDetained;
        }
    }
}
