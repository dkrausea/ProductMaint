using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JQueryDataTables.Models;


namespace JQueryDataTables.Models.Repository
{
    /// <summary>
    /// Repository class - contains hardcoded data
    /// </summary>
    public class DataRepository
    {
        /// <summary>
        /// Singleton collection of companies
        /// </summary>
        public static IList<Company> CompanyData = null;

        /// <summary>
        /// Method that returns all companies used in this example
        /// </summary>
        /// <returns>List of companies</returns>
        public static IList<Company> GetCompanies()
        {
            if (CompanyData == null)
            {
                CompanyData = new List<Company>();

                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5788 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "WA" });
                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5808 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "WB" });
                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5828 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "WC" });
                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5737 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "WD" });
                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5764 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "WE" });
                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5754 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "WT" });
                CompanyData.Add(new Company() { Name = "Qualcomm", Address = "5751 Pacific Center Blvd.", City = "San Diego", State = "CA", PostalCode = "92121", Building = "W" });
            }
            return CompanyData;
        }
    }
}