using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Assessment3.Models;

namespace Assessment3.Controllers
{
    public class LoginController : Controller
    {
        public bool IsActive { get; set; }
        private CDACEntities db = new CDACEntities();
        private CDACEntities1 db1 = new CDACEntities1();
        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.Logins.ToList());
        }
        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }
        public ActionResult List() // to Print list of all customers those are register
        {
            return View(db.Priyanka_New_Customer_Registrations.ToList());
        }
        public ActionResult LogIn()  //Login action
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Login reg)//Login action implementation
        {
            //var user = db.Priyanka_New_Customer_Registrations.Single(u => u.User_Name == reg.Username);
            //if (user.IsActive)
            //{
            //    ModelState.AddModelError("", "This account has been disabled");
            //    return View(reg);
            //}
            //else if (!user.IsActive)
            //{
                if (ModelState.IsValid)
                {
                    var details = (from userlist in db.Priyanka_New_Customer_Registrations
                                   where userlist.User_Name == reg.Username && userlist.Password == reg.Password
                                   select new
                                   {
                                       userlist.Customer_ID,
                                       userlist.User_Name
                                   }).ToList();
                    if (details.FirstOrDefault() != null)
                    {

                    if (!IsActive == true)
                    {
                        Session["Customer_ID"] = details.FirstOrDefault().Customer_ID;
                        Session["User_Name"] = details.FirstOrDefault().User_Name;
                        return RedirectToAction("Details/" + Session["Customer_ID"], "Priyanka_New_Customer_Registrations");
                    }
                    else
                    {
                        ModelState.AddModelError("", "This account has been disabled");
                           return View(reg);
                    }
                }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                }
          // }
            return View(reg);
        }
        [HttpPost]
        public ActionResult EditUser(Priyanka_New_Customer_Registrations model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return View("LogIn");
        }
        public ActionResult LogOut()  //Logout Action
        {
            FormsAuthentication.SignOut();   // method of forms authentiction to logout user
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Priyanka_Admin reg)      //Admin Login  Action
        {
            try                                   //handling exception
            {
                if (ModelState.IsValid)
                {
                    var details = (from userlist in db1.Priyanka_Admin                      // to cheack user name password validation
                                   where userlist.Username == reg.Username && userlist.Password == reg.Password
                                   select new
                                   {
                                       userlist.UserId,
                                       userlist.Username,
                                   }).ToList();
                  if (details.FirstOrDefault() != null)
                    {
                        Session["UserId"] = details.FirstOrDefault().UserId;
                        Session["Username"] = details.FirstOrDefault().Username;
                        return RedirectToAction("List");
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(reg);
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
