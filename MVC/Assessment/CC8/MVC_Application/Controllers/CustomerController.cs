using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application.Models;

namespace MVC_Application.Controllers
{
    public class CustomerController : Controller
    {
        Northwind_MVC_DBEntities1 db = new Northwind_MVC_DBEntities1();

        public ActionResult Index()
        {
            return View();

        }
        public ActionResult CustomersInGermany()
        {
            var cust = db.Customers.
                Where(c => c.Country == "Germany").ToList();
            return View(cust);
        }

        public ActionResult CustomerByOrder()
        {
            var cust = (from o in db.Orders
                        where o.OrderID == 1
                        select o.Customer).FirstOrDefault();
            return View(cust);
        }

    }
}