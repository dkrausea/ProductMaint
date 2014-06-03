using System.Collections.Generic;
using System.Web.Http;

namespace SelectionSample.Controllers
{
    public class Employee
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class EmployeeController : ApiController
    {
        private static List<Employee> _employees = new List<Employee>
           
         {
            new Employee { id = 1, text = "johnk"},
            new Employee { id = 2, text = "russm"},
            new Employee { id = 3, text = "johnb"},
         };

        // GET api/employee
        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        // GET api/employee/5
        public Employee Get(int id)
        {
            return _employees.Find(e => e.id == id);
        }

        public IEnumerable<Employee> Get(string callback, string q, int page_limit, string u)
        {
            return _employees.FindAll(e => e.text.StartsWith(q));
        }

        // POST api/employee
        public void Post([FromBody]Employee value)
        {
            _employees.Add(value);
        }

        // PUT api/employee/5
        public void Put(int id, [FromBody]Employee value)
        {
            Employee employee = _employees.Find(e => e.id == id);
            employee = value;
        }

        // DELETE api/employee/5
        public void Delete(int id)
        {
            _employees.Remove(_employees.Find(e => e.id == id));
        }
    }
}
