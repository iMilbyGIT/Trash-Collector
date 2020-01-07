using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.IsInRole("Customer")){
                return RedirectToAction("Index", "Customers");
            } else if (User.IsInRole("Employee")){
                return RedirectToAction("Index", "Employees");
            }else{
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("About", "Customers");
            }
            else if (User.IsInRole("Employee"))
            {
                return RedirectToAction("About", "Employees");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Contact", "Customers");
            }
            else if (User.IsInRole("Employee"))
            {
                return RedirectToAction("Contact", "Employees");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}