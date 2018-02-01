using System;
using System.Collections.Generic;
using System.Linq;

namespace MMSG.Automation.DataTransferObjects
{
    class Package : BaseEntityObject
    {
        /// <summary>
        /// This is the Employer Short Name of the user.
        /// </summary>
        public String EmployerShortName { get; set; }

        /// <summary>
        /// This is the first name of the user.
        /// </summary>
        public String Offering { get; set; }

        /// <summary>
        /// This is the middle name of the user.
        /// </summary>
        public String EmployerCode { get; set; }

        /// <summary>
        /// This is the last name of the user.
        /// </summary>
        public String OfferingName { get; set; }

        /// <summary>
        /// This is Given name of the user.
        /// </summary>
        public string FinancialAdviser { get; set; }

        /// <summary>
        /// This is the type of the Package
        /// </summary>
        public enum PackageTypeEnum
        {
            #region User Types
            AATPackage = 1,
            ABOTSPackage = 2,
            AC3Package = 3,
            ACAREPackage = 4,
            ACASAPackage = 5,
            ACCSAPackage = 6,
            ACIWWPackage = 7,
            ACSAGPackage = 8,
            ACTEPackage = 9,
            ACTIVPackage = 10,
            ADFCPackage = 11,
            ADMIPackage = 12,
            ADOMPackage = 13,
            ADRAAPackage = 14,
            AFCPackage = 15,
            AFCSAPackage = 16,
            AGCNPackage = 17,
            AGCOOPackage = 18,
            AGCPLPackage = 19,
            AGCQPackage = 20,
            AGCSPackage = 21,
            AHIPackage = 22,
            AHOPackage = 23,
            AIATSPackage = 24,
            ALMBIPackage = 25,
            ALSTGPackage = 26,
            ALTRPackage = 27,
            ALTSAPackage = 28,
            AMBEXPackage = 29,
            AMBHDPackage = 30,
            AMCPackage = 31,
            AMGRPackage = 32,
            AMLPackage = 33,
            AMSCOPackage = 34,
            ANGLPackage = 35,
            ANNMPackage = 36,
            ANSTOPackage = 37,
            AOTPackage = 38,
            APNPackage = 39,
            APOLPackage = 40,
            ARCSPackage = 41,
            ARTSAPackage = 42,
            ARVPackage = 43,
            ASCPackage = 44,
            ASGPackage = 45,
            ASOPackage = 46,
            AVMPackage = 47,
            AWHPackage = 48,
            AWHNPackage = 49,
            AWHVPackage = 50,
            BAYHPackage = 51,
            DAAPackage = 52,
            DADHCPackage = 53,
            GIAPackage = 54,
            HLASCPackage = 55,
            HLASNPackage = 56,
            HOSTPackage = 57,
            ILACTPackage = 58,
            ILAGCPackage = 59,
            ILAGLPackage = 60,
            ILAPLPackage = 61,
            ILAWLPackage = 62,
            ILUCMPackage = 63,
            LGACPackage = 64,
            OAMPSPackage = 65,
            RCHCPackage = 66,
            RIOADPackage = 67,
            SCHWEPackage = 68,
            SDAACPackage = 69,
            SLSAPackage = 70,
            TAIGPackage = 71,
            TRITMPackage = 72,
            WBTSAPackage = 73,
            ZAHIPackage = 74,
            #endregion
        }


        /// <summary>
        /// This is the type of the user.
        /// </summary>
        public PackageTypeEnum PackageType { get; set; }


        /// <summary>
        /// This method selects users based on given condition.
        /// </summary>
        /// <param name="predicate">The condition</param>
        /// <returns>A list of users</returns>
        public static List<Package> Get(Func<Package, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method inserts a new user into the system.
        /// </summary>]
        public void StoreUserInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateUserInMemory(Package package)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(package);
        }

        /// <summary>
        /// This method selects a single user based on the role.
        /// </summary>
        /// <param name="packageType">This is the user type.</param>
        /// <returns>A single user.</returns>
        public static Package Get(PackageTypeEnum packageType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany
                <Package>(x => x.PackageType == packageType && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }


        /// <summary>
        /// This method returns all created users of the given type.
        /// </summary>
        /// <param name="userType">This is the type of the user.</param>
        /// <returns>User List.</returns>
        public static List<Package> GetAll(PackageTypeEnum packageType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Package>(
                x => x.PackageType == packageType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}