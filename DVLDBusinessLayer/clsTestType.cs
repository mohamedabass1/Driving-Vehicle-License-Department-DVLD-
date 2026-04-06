using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsTestType
    {

        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        public enTestType ID { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestType()
        {

            this.ID = enTestType.VisionTest;

            this.Title = "";
            this.Description = "";
            this.Fees = 0;

            _Mode = enMode.AddNew;
        }
        private clsTestType(enTestType ID, string Title, string Description, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;

            _Mode = enMode.Update;
        }

        public static clsTestType Find(enTestType TestTypeID)
        {
            string TestTypeTitle = "";
            string Description = "";
            float TestTypeFees = 0;

            if (clsTestType_Data.GetTestTypeInfo((int)TestTypeID, ref TestTypeTitle, ref Description, ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, Description, TestTypeFees);
            }
            else
                return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestType_Data.GetAllTestTypes();
        }

        private bool _AddNewTestType()
        {
            this.ID = (enTestType)clsTestType_Data.AddNewTestType(this.Title, this.Description, this.Fees);

            return ((int)this.ID != -1);
        }
        private bool _UpdateTestType()
        {
            return clsTestType_Data.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewTestType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTestType();

            }

            return false;
        }
    }
}
