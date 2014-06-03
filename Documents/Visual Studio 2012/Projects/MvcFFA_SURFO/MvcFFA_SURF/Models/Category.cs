using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFFA_SURF.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}