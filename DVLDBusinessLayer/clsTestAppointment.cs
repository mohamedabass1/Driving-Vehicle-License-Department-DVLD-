using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsTestAppointment
    {

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public clsTestType TestTypeInfo;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication localDrivingLicenseApplicationInfo;
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplicationInfo;

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;

            _Mode = enMode.AddNew;
        }

        public clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
           DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.TestTypeInfo = clsTestType.Find((clsTestType.enTestType)TestTypeID);

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.localDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;

            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindUserByUserID(CreatedByUserID);

            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);

            _Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointments_Data.AddNewTestAppointment(this.TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                                                                                    PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _Update()
        {
            return clsTestAppointments_Data.UpdateTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNewTestAppointment())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }

            return _Update();
        }


        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;


            bool IsFuond = clsTestAppointments_Data.GetTestAppointmentByAppointmentID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

            if (IsFuond)
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
                return null;
        }

        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            bool IsFound = clsTestAppointments_Data.GetLastTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID, ref TestAppointmentID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

            if (IsFound)
            {

                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                   AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
                return null;
        }

        public static DataTable GetAppliationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_Data.GetAppliationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }


        //*****************//

        public static bool IsExistsByTestAppointmentID(int TestAppointmentID)
        {
            return clsTestAppointments_Data.IsExistsByTestAppointmentID(TestAppointmentID);

        }

        public static bool IsAppointmentLocked(int TestAppointmentID)
        {
            return clsTestAppointments_Data.IsAppointmentLocked(TestAppointmentID);
        }

        public static bool HasActiveTestAppointmentForLocalApplicationIDAndTestTypeID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_Data.HasTestActiveAppointmentForLocalApplicationIDAndTestTypeID(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool SetLockedAppointment(int TestAppointmentID)
        {
            return clsTestAppointments_Data.SetLockedAppointment(TestAppointmentID);
        }
    }
}
