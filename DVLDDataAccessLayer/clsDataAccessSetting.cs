using System.Configuration;
namespace DVLD_DataAccess
{
    public static class clsDataAccessSetting
    {
        // public static string ConnectionString = @"Server =.; Database= DVLD1; User Id = sa; Password =123456";

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DVLD_Connection"].ConnectionString;
    }

}
