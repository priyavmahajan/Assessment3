using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assessment3.Models;

namespace Assessment3.Controllers
{
    public class Priyanka_New_Customer_RegistrationsController : Controller
    {
        private CDACEntities db = new CDACEntities();

        // GET: Priyanka_New_Customer_Registrations
        public ActionResult Index()
        {
            return View(db.Priyanka_New_Customer_Registrations.ToList());
        }

        // GET: Priyanka_New_Customer_Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priyanka_New_Customer_Registrations priyanka_New_Customer_Registrations = db.Priyanka_New_Customer_Registrations.Find(id);
            if (priyanka_New_Customer_Registrations == null)
            {
                return HttpNotFound();
            }
            return View(priyanka_New_Customer_Registrations);
        }

        // GET: Priyanka_New_Customer_Registrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Priyanka_New_Customer_Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,User_Name,Password,Confirm_Password,Email")] Priyanka_New_Customer_Registrations priyanka_New_Customer_Registrations)
        {
            if (ModelState.IsValid)
            {
                db.Priyanka_New_Customer_Registrations.Add(priyanka_New_Customer_Registrations);
                db.SaveChanges();
                return RedirectToAction("LogIn","Login");
            }

            return View(priyanka_New_Customer_Registrations);
        }
        public ActionResult wellcome()
        {
            return View();
        }
        // GET: Priyanka_New_Customer_Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priyanka_New_Customer_Registrations priyanka_New_Customer_Registrations = db.Priyanka_New_Customer_Registrations.Find(id);
            if (priyanka_New_Customer_Registrations == null)
            {
                return HttpNotFound();
            }
            return View(priyanka_New_Customer_Registrations);
        }

        // POST: Priyanka_New_Customer_Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_ID,User_Name,Password,Confirm_Password,Email")] Priyanka_New_Customer_Registrations priyanka_New_Customer_Registrations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priyanka_New_Customer_Registrations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priyanka_New_Customer_Registrations);
        }

        // GET: Priyanka_New_Customer_Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priyanka_New_Customer_Registrations priyanka_New_Customer_Registrations = db.Priyanka_New_Customer_Registrations.Find(id);
            if (priyanka_New_Customer_Registrations == null)
            {
                return HttpNotFound();
            }
            return View(priyanka_New_Customer_Registrations);
        }

        // POST: Priyanka_New_Customer_Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priyanka_New_Customer_Registrations priyanka_New_Customer_Registrations = db.Priyanka_New_Customer_Registrations.Find(id);
            db.Priyanka_New_Customer_Registrations.Remove(priyanka_New_Customer_Registrations);
            db.SaveChanges();
            return RedirectToAction("LogIn","Login");
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
