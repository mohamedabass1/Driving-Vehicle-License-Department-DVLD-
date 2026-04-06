using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsLicenseClass
    {

        public int ID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinimumAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.ID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
        }

        private clsLicenseClass(int ID, string ClassName, string ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, float ClassFees)
        {
            this.ID = ID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            short MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClasses_Data.GetClassInfoByLicenseClassID(LicenseClassID, ref ClassName, ref ClassDescription,
                ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                 MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
                return null;
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            short MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClasses_Data.GetClassInfoByLicenseClassName(ClassName, ref LicenseClassID, ref ClassDescription,
                ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                 MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
                return null;
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClasses_Data.GetAllLicenseClasses();
        }
    }
}
