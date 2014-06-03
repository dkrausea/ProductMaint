using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFFA_SURF.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string QUserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Category> categories{ get; set; }
    }
}