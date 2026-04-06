using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsLicenseClasses_Data
    {
        public static bool GetClassInfoByLicenseClassID(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref short MinimumAllowedAge, ref short DefaultValidityLength, ref float ClassFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from LicenseClasses
                             Where LicenseClassID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = Convert.ToInt16(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt16(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                    isFound = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                isFound = false;
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetClassInfoByLicenseClassName(string ClassName, ref int ID, ref string ClassDescription, ref short MinimumAllowedAge, ref short DefaultValidityLength, ref float ClassFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from LicenseClasses
                             Where ClassName = @ClassName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToInt16(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt16(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                    isFound = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                isFound = false;
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllLicenseClasses()
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * From LicenseClasses;";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtLicenseClasses = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtLicenseClasses.Load(reader);

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

            return dtLicenseClasses;
        }

    }
}
