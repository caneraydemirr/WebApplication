using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ShippersController : Controller
    {
        ShippersDAL shippersDAL = new ShippersDAL();
        List<Shippers> shipperList = new List<Shippers>();
        // GET: Shippers
        public ActionResult Index()
        {
            shipperList = shippersDAL.GetAllShippers();
            return View(shipperList);
        }

        [HttpGet]
        public ActionResult AddShipper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddShipper(Shippers shippers)
        {
            ShippersValidator shippersValidator = new ShippersValidator();
            ValidationResult results = shippersValidator.Validate(shippers);
            if (results.IsValid)
            {
                shippersDAL.CreateShipper(shippers);
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

        public ActionResult DeleteShipper(int id) 
        {
            shippersDAL.DeleteShipper(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditShipper(int id)
        {
            Shippers shippers = shippersDAL.GetShipperById(id);
            return View(shippers);
        }
        [HttpPost]
        public ActionResult EditShipper(Shippers shippers)
        {
            ShippersValidator shippersValidator = new ShippersValidator();
            ValidationResult results = shippersValidator.Validate(shippers);
            if (results.IsValid)
            {
                shippersDAL.UpdateShipper(shippers.ShipperID, shippers);
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