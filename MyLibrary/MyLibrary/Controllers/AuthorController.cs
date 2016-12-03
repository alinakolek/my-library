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
    public class AuthorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Author/AuthorIndex
        public ActionResult AuthorIndex()
        {
            return View(db.Authors.ToList());
        }

        /*
        // GET: Author/AuthorDetails/5
        public ActionResult AuthorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }
        */

        // GET: Author/AuthorCreate
        public ActionResult AuthorCreate()
        {
            return View();
        }

        // POST: Author/AuthorCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorCreate([Bind(Include = "Books,Id,Forename,Surname")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Author record");
                return RedirectToAction("AuthorIndex");
            }

            DisplayErrorMessage();
            return View(author);
        }

        // GET: Author/AuthorEdit/5
        public ActionResult AuthorEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: AuthorAuthor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorEdit([Bind(Include = "Books,Id,Forename,Surname")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Author record");
                return RedirectToAction("AuthorIndex");
            }
            DisplayErrorMessage();
            return View(author);
        }

        // GET: Author/AuthorDelete/5
        public ActionResult AuthorDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Author/AuthorDelete/5
        [HttpPost, ActionName("AuthorDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorDeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Author record");
            return RedirectToAction("AuthorIndex");
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
