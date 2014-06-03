using System.Web.Mvc;

namespace WithAutomapper.Models
{
    public class CustomerInput
    {
        public string NameFirst { get; set; }
        public string NameLast { get; set; }

        public string StatusValue { get; set; }

        public SelectList AllStatuses { get; set; }
    }
}