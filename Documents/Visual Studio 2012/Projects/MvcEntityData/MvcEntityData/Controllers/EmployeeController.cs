using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityData.Models;

namespace MvcEntityData.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Details(int id)
        {

            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeID == id);

            //Employee employee = new Employee()
            //{
            //    EmployeeID = 101,
            //    Name = "Don",
            //    Gender = "Male",
            //    City = "San Diego"
            //};
            return View(employee);
        }

    }
}
