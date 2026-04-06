using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsTest
    {

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }

        public clsTestAppointment TestAppointmentInfo;
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }



        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.Find(this.TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTests_Data.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTests_Data.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public static clsTest GetTestByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            bool IsFound = clsTests_Data.GetTestByTestAppointmentID(TestAppointmentID,
                ref TestID, ref TestResult, ref Notes, ref CreatedByUserID);


            if (IsFound)
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }

            return null;
        }
        public static clsTest GetTestByTestID(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            bool IsFound = clsTests_Data.GetTestByTestID(TestID,
                ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);


            if (IsFound)
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }

            return null;
        }

        public static DataTable GetAllTests()
        {
            return clsTests_Data.GetAllTests();
        }
        public static clsTest GetLastTestPerApplicationIDAndTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            bool IsFound = clsTests_Data.GetLastTestPerApplicationIDAndTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID, ref TestID,
                ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);


            if (IsFound)
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }

            return null;

        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNewTest())
                {
                    _Mode = enMode.Update;
                    return true;

                }

            }
            else
            {
                return _UpdateTest();
            }

            return false;
        }

        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTests_Data.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }


    }
}
