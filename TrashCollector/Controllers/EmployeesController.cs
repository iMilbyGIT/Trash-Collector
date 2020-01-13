using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public bool IsPickupConfirmed(Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();

            if (customer.pickupConfirm == true)
            {
                db.Entry(customer.balance + 25).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (customer.pickupConfirm == false)
            {
                db.Entry(customer.pickupConfirm).State = EntityState.Unchanged;
                db.SaveChanges();
            }
            return customer.pickupConfirm;
        }
        public ActionResult PersonalCustIndex()
        {
            var Id = User.Identity.GetUserId();
            var currentEmpl = db.Employees.Where(e => e.ApplicationId == Id).SingleOrDefault();
            string todayDay = DateTime.Today.ToShortDateString();
            var customers = db.Customers.Include(c => c.ApplicationUser).Where(c => c.zip == currentEmpl.zip).ToList();
            return View(customers);
        }
        public ActionResult GetCustByDay()
        {
            DateTime rightmeow = DateTime.Today;
            string currentDay = rightmeow.Day.ToString();
            var id = User.Identity.GetUserId();
            var currentEmpl = db.Employees.Where(e => e.ApplicationId == id).SingleOrDefault();
            var cust = db.Customers.Include(c => c.ApplicationUser).Where(c => c.pickupDay == currentDay && c.zip == currentEmpl.zip).ToList();
            return View("PersonalCustIndex", cust);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalCustIndex([Bind(Include = "Id,pickupDay,firstName,lastName,extraPickupDate,streetAddress,zip,balance,suspendedStart,suspendedEnd,pickupConfirm")]Customer customer)
        {
            if (customer.pickupConfirm == true)
            {
                string currentUserId = User.Identity.GetUserId();
                var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
                db.Entry(customer.balance + 25).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PersonalCustIndex", customer);
            }
            else if (customer.pickupConfirm == false)
            {
                return View("PersonalCustIndex", customer);
            }

            return View("PersonalCustIndex", customer);
        }
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", employee);
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", employee);
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
