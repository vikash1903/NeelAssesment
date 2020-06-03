using Neel.Core.DataAccess;
using Neel.Core.DataAccess.Repository;
using Neel.Core.Models.Interface;
using Neel.Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeelAssesment.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        private EmployeeServices employeeService = new EmployeeServices();
        //public EmployeesController(
        //    IEmployeeServices employeeService)
        //{
        //    this.employeeService = employeeService;
        //}
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.employee.ToList());
        }
        public ActionResult AddEditEmployee(string empId)
        {
            EmployeeModel getemployeelist = new EmployeeModel();
            if (!string.IsNullOrEmpty(empId))
            {
                int id = Convert.ToInt32(empId);
                getemployeelist = db.employee.Where(c => c.EmployeeId == id).FirstOrDefault();
            }
            return View(getemployeelist);
        }


        [HttpPost]
        public JsonResult AddEditEmployee([Bind(Include = "EmployeeId,EmployeeName,Designation,MobileNumber,BloodGroup,Salary")] EmployeeModel employee)
        {
            string msg = string.Empty;
            msg = "Something went wrong";
            if (ModelState.IsValid)
            {
                if (employee.EmployeeName != null)
                {
                    if (employee.EmployeeId != 0)
                    {
                        msg = "Record is updated sucessfully";
                        db.Entry(employee).State = EntityState.Modified;
                    }
                    else
                    {
                        db.employee.Add(employee);
                        msg = "Data is saved successfully";
                    }
                    db.SaveChanges();
                }
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteEmployeeById(string EmployeeId)
        {
            bool result = false;
            result = employeeService.DeleteRecord(string.IsNullOrEmpty(EmployeeId) ? 0 : Convert.ToInt32(EmployeeId));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}