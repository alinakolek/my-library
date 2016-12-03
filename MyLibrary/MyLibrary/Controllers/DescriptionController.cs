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
    public class DescriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Description/DescriptionIndex
        public ActionResult DescriptionIndex()
        {
            var description = db.Descriptions.Include(d => d.Book);
            return View(description.ToList());
        }

        /*
        // GET: Description/DescriptionDetails/5
        public ActionResult DescriptionDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }
        */

        // GET: Description/DescriptionCreate
        public ActionResult DescriptionCreate()
        {
            ViewBag.Id = new SelectList(db.Books, "Id", "Title");
            return View();
        }

        // POST: Description/DescriptionCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DescriptionCreate([Bind(Include = "Book,Id,DescriptionContent")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Descriptions.Add(description);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Description record");
                return RedirectToAction("DescriptionIndex");
            }

            ViewBag.Id = new SelectList(db.Books, "Id", "Title", description.Id);
            DisplayErrorMessage();
            return View(description);
        }

        // GET: Description/DescriptionEdit/5
        public ActionResult DescriptionEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Books, "Id", "Title", description.Id);
            return View(description);
        }

        // POST: DescriptionDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DescriptionEdit([Bind(Include = "Book,Id,DescriptionContent")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(description).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Description record");
                return RedirectToAction("DescriptionIndex");
            }
            ViewBag.Id = new SelectList(db.Books, "Id", "Title", description.Id);
            DisplayErrorMessage();
            return View(description);
        }

        // GET: Description/DescriptionDelete/5
        public ActionResult DescriptionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Description/DescriptionDelete/5
        [HttpPost, ActionName("DescriptionDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DescriptionDeleteConfirmed(int id)
        {
            Description description = db.Descriptions.Find(id);
            db.Descriptions.Remove(description);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Description record");
            return RedirectToAction("DescriptionIndex");
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
