using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        EmployeesDAL employeesDAL = new EmployeesDAL();
        List<Employees> employeeList = new List<Employees>();
        public ActionResult Index()
        {
            employeeList = employeesDAL.GetAllEmployees();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employees employees)
        {
            EmployeesValidator validationRules = new EmployeesValidator();
            ValidationResult results = validationRules.Validate(employees);
            if (results.IsValid)
            {
                employeesDAL.CreateEmployee(employees);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteEmployee(int id)
        {
            employeesDAL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            Employees employees = employeesDAL.GetEmployeeById(id);
            return View(employees);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employees employees)
        {
            EmployeesValidator validationRules = new EmployeesValidator();
            ValidationResult results = validationRules.Validate(employees);
            if (results.IsValid)
            {
                employeesDAL.UpdateEmployee(employees.EmployeeID, employees);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}