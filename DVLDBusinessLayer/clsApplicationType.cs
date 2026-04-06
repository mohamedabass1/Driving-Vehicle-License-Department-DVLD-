using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsApplicationType
    {

        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;


        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public clsApplicationType()
        {

            this.ID = -1;
            this.Title = "";
            this.Fees = 0;

            _Mode = enMode.AddNew;
        }
        private clsApplicationType(int ID, string Title, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;

            _Mode = enMode.Update;
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;

            if (clsApplicationType_Data.GetApplicationTypeInfo(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            else
                return null;


        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationType_Data.GetAllApplicationTypes();
        }

        private bool _AddNewApplicationType()
        {
            this.ID = clsApplicationType_Data.AddNewApplicationType(this.Title, this.Fees);

            return (this.ID != -1);
        }
        private bool _UpdateApplicationType()
        {
            return clsApplicationType_Data.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewApplicationType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplicationType();

            }

            return false;
        }


    }
}
