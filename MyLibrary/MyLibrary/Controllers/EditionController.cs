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
    public class EditionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Edition/EditionIndex
        public ActionResult EditionIndex()
        {
            var edition = db.Editions.Include(e => e.BookStatus).Include(e => e.ISBN);
            return View(edition.ToList());
        }

        /*
        // GET: Edition/EditionDetails/5
        public ActionResult EditionDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edition edition = db.Editions.Find(id);
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }
        */

        // GET: Edition/EditionCreate
        public ActionResult EditionCreate()
        {
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName");
            ViewBag.Id = new SelectList(db.ISBNs, "Id", "ISBNNumber");
            return View();
        }

        // POST: Edition/EditionCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditionCreate([Bind(Include = "BookStatus,ISBN,PublishingHouses,Id,PublicationDate,PublicationPlace,PublicationIssueNumber")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                db.Editions.Add(edition);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Edition record");
                return RedirectToAction("EditionIndex");
            }

            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", edition.Id);
            ViewBag.Id = new SelectList(db.ISBNs, "Id", "ISBNNumber", edition.Id);
            DisplayErrorMessage();
            return View(edition);
        }

        // GET: Edition/EditionEdit/5
        public ActionResult EditionEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edition edition = db.Editions.Find(id);
            if (edition == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", edition.Id);
            ViewBag.Id = new SelectList(db.ISBNs, "Id", "ISBNNumber", edition.Id);
            return View(edition);
        }

        // POST: EditionEdition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditionEdit([Bind(Include = "BookStatus,ISBN,PublishingHouses,Id,PublicationDate,PublicationPlace,PublicationIssueNumber")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edition).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Edition record");
                return RedirectToAction("EditionIndex");
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", edition.Id);
            ViewBag.Id = new SelectList(db.ISBNs, "Id", "ISBNNumber", edition.Id);
            DisplayErrorMessage();
            return View(edition);
        }

        // GET: Edition/EditionDelete/5
        public ActionResult EditionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edition edition = db.Editions.Find(id);
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // POST: Edition/EditionDelete/5
        [HttpPost, ActionName("EditionDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EditionDeleteConfirmed(int id)
        {
            Edition edition = db.Editions.Find(id);
            db.Editions.Remove(edition);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Edition record");
            return RedirectToAction("EditionIndex");
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
