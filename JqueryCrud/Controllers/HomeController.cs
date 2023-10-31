using JqueryCrud.InterFace;
using JqueryCrud.Models;
using JqueryCrud.Repositer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewBag.l_data = GetEmployee();
            return View(GetEmployee());
        }
        [HttpGet]
         IEnumerable<EmployeeModel> GetEmployee()
        {
            HomeRepository l_AllEmp =  new HomeRepository();
            List<EmployeeModel> a_data = l_AllEmp.GetEmply();
            return a_data;
        }
        [HttpPost]
        public ActionResult Save(EmployeeModel employee)
        {
            EmployeeModel l_emp = new EmployeeModel();
            l_emp.FirstName = employee.FirstName;
            HomeRepository l_SaveEmp = new HomeRepository();
            l_SaveEmp.SaveEmply(l_emp);
            return View();
        }

    }
}