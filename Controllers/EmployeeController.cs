using EmployeeLib.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly EmployeeComponent empObj = new  EmployeeComponent();
        // GET: EmpDept
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllEmployees()
        {
            var allEmp = empObj.GetAllEmployees();
            return PartialView(allEmp);
        }
        public ActionResult Add()
        {
            return PartialView(new Employee());
        }
        [HttpPost]

        public ActionResult Add(Employee employee)
        {
            empObj.AddNewEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Update(string id)
        {
            var selectedId = int.Parse(id);
            var foundEmp = empObj.FindEmployee(selectedId);
            return View(foundEmp);
        }

        [HttpPost]

        public ActionResult Update(Employee employee)
        {
            empObj.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var selectedId = int.Parse(id);
            empObj.DeleteEmployee(selectedId);
            return RedirectToAction("Index");
        }

    }
}