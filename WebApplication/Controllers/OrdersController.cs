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
    public class OrdersController : Controller
    {
        DataAccessLayer.LogsDAL LogsDAL = new LogsDAL();
        Logs logs = new Logs();
        // GET: Orders
        OrdersDAL ordersDAL = new OrdersDAL();
        List<Orders> orderList = new List<Orders>();
        public ActionResult Index()
        {
            orderList = ordersDAL.GetAllOrders();
            return View(orderList);
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            /*CustomersDAL customersDAL = new CustomersDAL();
            var customerList=new List<Customers>();
            customerList = customersDAL.GetAllCustomers();

            EmployeesDAL employeesDAL = new EmployeesDAL();
            var employeeList = new List<Employees>();
            employeeList = employeesDAL.GetAllEmployees();

            orderList = ordersDAL.GetAllOrders();

            var viewModel = new MyViewModel(orderList, customerList, employeeList);*/
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Orders orders)
        {
            OrdersValidator validationRules = new OrdersValidator();
            ValidationResult results = validationRules.Validate(orders);
            if (results.IsValid)
            {
                ordersDAL.CreateOrder(orders);
                logs.Name = "Order";
                logs.Date = DateTime.Now;
                logs.UserName = "Deneme";
                logs.Type = "Add";
                LogsDAL.CreateLog(logs);
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

        public ActionResult DeleteOrder(int id)
        {
            ordersDAL.DeleteOrder(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            Orders orders = ordersDAL.GetOrderById(id);
            return View(orders);
        }
        [HttpPost]
        public ActionResult EditOrder(Orders orders)
        {
            OrdersValidator validationRules = new OrdersValidator();
            ValidationResult results = validationRules.Validate(orders);
            if (results.IsValid)
            {
                ordersDAL.UpdateOrder(orders.OrderID, orders);
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