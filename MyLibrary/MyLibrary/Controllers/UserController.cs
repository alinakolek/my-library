using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.DBContext;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User/UserIndex
        public ActionResult UserIndex()
        {
            var user = db.Users.Include(u => u.BookStatus);
            return View(user.ToList());
        }

        /*
        // GET: User/UserDetails/5
        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        */

        // GET: User/UserCreate
        public ActionResult UserCreate()
        {
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName");
            return View();
        }

        // POST: User/UserCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate([Bind(Include = "BookStatus,Id,Forename,Surname")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a User record");
                return RedirectToAction("UserIndex");
            }

            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", user.Id);
            DisplayErrorMessage();
            return View(user);
        }

        // GET: User/UserEdit/5
        public ActionResult UserEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", user.Id);
            return View(user);
        }

        // POST: UserUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit([Bind(Include = "BookStatus,Id,Forename,Surname")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a User record");
                return RedirectToAction("UserIndex");
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", user.Id);
            DisplayErrorMessage();
            return View(user);
        }

        // GET: User/UserDelete/5
        public ActionResult UserDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/UserDelete/5
        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UserDeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a User record");
            return RedirectToAction("UserIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
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
