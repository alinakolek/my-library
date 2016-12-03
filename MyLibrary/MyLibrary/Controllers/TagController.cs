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
    public class TagController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tag/TagIndex
        public ActionResult TagIndex()
        {
            return View(db.Tags.ToList());
        }

        /*
        // GET: Tag/TagDetails/5
        public ActionResult TagDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        */

        // GET: Tag/TagCreate
        public ActionResult TagCreate()
        {
            return View();
        }

        // POST: Tag/TagCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TagCreate([Bind(Include = "Book,Id,Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Tag record");
                return RedirectToAction("TagIndex");
            }

            DisplayErrorMessage();
            return View(tag);
        }

        // GET: Tag/TagEdit/5
        public ActionResult TagEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: TagTag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TagEdit([Bind(Include = "Book,Id,Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Tag record");
                return RedirectToAction("TagIndex");
            }
            DisplayErrorMessage();
            return View(tag);
        }

        // GET: Tag/TagDelete/5
        public ActionResult TagDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tag/TagDelete/5
        [HttpPost, ActionName("TagDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TagDeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Tag record");
            return RedirectToAction("TagIndex");
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
