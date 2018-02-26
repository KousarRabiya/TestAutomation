using System.Collections.Generic;
using System.Linq;

namespace MMSG.Automation.DataTransferObjects
{
    /// <summary>
    /// This class represents a Benefit.
    /// </summary>
    public class Benefit : BaseEntityObject
    {
        /// <summary>
        /// This is h type of benefit.
        /// </summary>
        public enum BenefitTypeEnum
        {
            #region Benefit Types
            // packages
            PHCNBenefit = 1,
            #endregion
        }

        /// <summary>
        /// This is the benefit type enum.
        /// </summary>
        public BenefitTypeEnum BenefitType { get; set; }

         /// <summary>
        /// This is benefit benifit type
        /// </summary>
        public string Benefit1 { get; set; }

        /// <summary>
        /// This is benefit benifit type
        /// </summary>
        public string Benefit2 { get; set; }

        /// <summary>
        /// This is benefit benifit type
        /// </summary>
        public string Benefit3 { get; set; }

        /// <summary>
        /// This is benefit benifit type
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
        /// This method selects the benefit of given type which is created.
        /// </summary>
        /// <param name="benefitType">This is the type of the benefit.</param>
        /// <returns>A benefit</returns>
        public static Benefit Get(BenefitTypeEnum benefitType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Benefit>
                (x => x.BenefitType == benefitType && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// This class creates a new Benefit.
        /// </summary>
        public void StoreBenefitInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method is used to update the benefit.
        /// </summary>
        public void UpdateBenefitInMemory(Benefit benefit)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(benefit);
        }

        /// <summary>
        /// This gets benefit based on name.
        /// </summary>
        /// <param name="name">The name of the benefit.</param>
        /// <returns>A single benefit</returns>
        public static Benefit Get(string name)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<Benefit>(x => x.Name == name && x.IsCreated);
        }

        /// <summary>
        /// This method returns all created benefit of the given type.
        /// </summary>
        /// <param name="benefitType">This is the type of the benefit.</param>
        /// <returns>benefit List.</returns>
        public static List<Benefit> GetAll(BenefitTypeEnum benefitType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Benefit>(
                x => x.BenefitType == benefitType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}