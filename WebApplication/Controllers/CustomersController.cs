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
    public class CustomersController : Controller
    {
        // GET: Customers
        CustomersDAL customersDAL = new CustomersDAL();
        List<Customers> customerList = new List<Customers>();
        public ActionResult Index()
        {
            customerList = customersDAL.GetAllCustomers();
            return View(customerList);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customers customers)
        {
            CustomersValidator validationRules = new CustomersValidator();
            ValidationResult results = validationRules.Validate(customers);
            if (results.IsValid)
            {
                customersDAL.CreateCustomer(customers);
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

        public ActionResult DeleteCustomer(string id)
        {
            customersDAL.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCustomer(string id)
        {
            Customers customers = customersDAL.GetCustomerById(id);
            return View(customers);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customers customers)
        {
            CustomersValidator validationRules = new CustomersValidator();
            ValidationResult results = validationRules.Validate(customers);
            if (results.IsValid)
            {
                customersDAL.UpdateCustomer(customers.CustomerID, customers);
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