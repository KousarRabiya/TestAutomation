using System;
using System.Collections.Generic;
using System.Linq;

namespace MMSG.Automation.DataTransferObjects
{
    /// <summary>
    /// This class represents a package.
    /// </summary>
    public class Package : BaseEntityObject
    {
        /// <summary>
        /// This is h type of package.
        /// </summary>
        public enum PackageTypeEnum
        {
            #region Package Types
            // packages
            NewPHCNPackage = 1,
            #endregion
        }

        /// <summary>
        /// This is the package type enum.
        /// </summary>
        public PackageTypeEnum PackageType { get; set; }

        /// <summary>
        /// This is the Employer Short Name of the user.
        /// </summary>
        public String EmployerShortName { get; set; }

        /// <summary>
        /// This is Living expense cap
        /// </summary>
        public string LivingExpenseCap { get; set; }

        /// <summary>
        /// This is Entertainment cap
        /// </summary>
        public string EntertainmentCap { get; set; }
        /// <summary>
        /// This is Employee email.
        /// </summary>
        public string BusinessEmail { get; set; }

        /// <summary>
        /// This is package benifit type
        /// </summary>
        public string Benefit1 { get; set; }

        /// <summary>
        /// This is package benifit type
        /// </summary>
        public string Benefit2 { get; set; }

        /// <summary>
        /// This is package benifit type
        /// </summary>
        public string Benefit3 { get; set; }

        /// <summary>
        /// This is package benifit type
        /// </summary>
        public string Benefit4 { get; set; }

        /// <summary>
        /// This is budget calculation method
        /// </summary>
        public string BudgetCalculationMethod { get; set; }

        /// <summary>
        /// This is BudgetAmount
        /// </summary>
        public string BudgetAmount { get; set; } 

        /// <summary>
        /// This is Employee Phone Nmumber
        /// </summary>
        public string BusinessPhone { get; set; }

        /// <summary>
        /// This is the setup Reason
        /// </summary>
        public string SetUpReason { get; set; }

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


        public String Template { get; set; }
        /// <summary>
        /// This class returns the package based on condition.
        /// </summary>
        /// <param name="predicate">This is the condition.</param>
        /// <returns>This is a list of packages.</returns>
        public static List<Package> Get(Func<Package, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method selects the package of given type which is created.
        /// </summary>
        /// <param name="packageType">This is the type of the package.</param>
        /// <returns>A package</returns>
        public static Package Get(PackageTypeEnum packageType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Package>              
                (x => x.PackageType == packageType && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// This class creates a new package.
        /// </summary>
        public void StorePackageInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method is used to update the package.
        /// </summary>
        public void UpdatePackageInMemory(Package package)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(package);
        }

        /// <summary>
        /// This gets package based on name.
        /// </summary>
        /// <param name="name">The name of the package.</param>
        /// <returns>A single package</returns>
        public static Package Get(string name)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<Package>(x => x.Name == name && x.IsCreated);
        }

        /// <summary>
        /// This method returns all created package of the given type.
        /// </summary>
        /// <param name="packageType">This is the type of the package.</param>
        /// <returns>package List.</returns>
        public static List<Package> GetAll(PackageTypeEnum packageType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Package>(
                x => x.PackageType == packageType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}