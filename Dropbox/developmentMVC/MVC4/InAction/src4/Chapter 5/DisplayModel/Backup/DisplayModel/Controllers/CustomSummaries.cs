using System.Collections.Generic;
using DisplayModel.Models;

namespace DisplayModel.Controllers
{
    public class CustomerSummaries
    {
        public IEnumerable<CustomerSummary> GetAll()
        {
            return new[]
            {
                new CustomerSummary
                {
                    Active = "Yes",
                    Name = "John Smith",
                    MostRecentOrderDate = "02/07/10",
                    OrderCount = "42",
                    ServiceLevel = "Standard"
                },
                new CustomerSummary
                {
                    Active = "Yes",
                    Name = "Susan Power",
                    MostRecentOrderDate = "02/02/10",
                    OrderCount = "1",
                    ServiceLevel = "Standard"
                },
                new CustomerSummary
                {
                    Active = "Yes",
                    Name = "Jim Doe",
                    MostRecentOrderDate = "02/09/10",
                    OrderCount = "7",
                    ServiceLevel = "Premier"
                },
            };
        }
    }
}