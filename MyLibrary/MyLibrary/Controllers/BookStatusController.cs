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
    public class BookStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookStatus/BookStatusIndex
        public ActionResult BookStatusIndex()
        {
            var bookStatus = db.BookStatuses.Include(b => b.CoverType).Include(b => b.Edition).Include(b => b.FileExtension).Include(b => b.Language).Include(b => b.User);
            return View(bookStatus.ToList());
        }

        /*
        // GET: BookStatus/BookStatusDetails/5
        public ActionResult BookStatusDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookStatus bookStatus = db.BookStatuses.Find(id);
            if (bookStatus == null)
            {
                return HttpNotFound();
            }
            return View(bookStatus);
        }
        */

        // GET: BookStatus/BookStatusCreate
        public ActionResult BookStatusCreate()
        {
            ViewBag.Id = new SelectList(db.CoverTypies, "Id", "Id");
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace");
            ViewBag.Id = new SelectList(db.FileExtensions, "Id", "Type");
            ViewBag.Id = new SelectList(db.Languages, "Id", "PublicationLanguage");
            ViewBag.Id = new SelectList(db.Users, "Id", "Forename");
            return View();
        }

        // POST: BookStatus/BookStatusCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookStatusCreate([Bind(Include = "Book,CoverType,Edition,FileExtension,Language,User,Id,IsAvailable,IsMissing,UserName,StartDate,EndDate")] BookStatus bookStatus)
        {
            if (ModelState.IsValid)
            {
                db.BookStatuses.Add(bookStatus);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a BookStatus record");
                return RedirectToAction("BookStatusIndex");
            }

            ViewBag.Id = new SelectList(db.CoverTypies, "Id", "Id", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace", bookStatus.Id);
            ViewBag.Id = new SelectList(db.FileExtensions, "Id", "Type", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Languages, "Id", "PublicationLanguage", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Users, "Id", "Forename", bookStatus.Id);
            DisplayErrorMessage();
            return View(bookStatus);
        }

        // GET: BookStatus/BookStatusEdit/5
        public ActionResult BookStatusEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookStatus bookStatus = db.BookStatuses.Find(id);
            if (bookStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.CoverTypies, "Id", "Id", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace", bookStatus.Id);
            ViewBag.Id = new SelectList(db.FileExtensions, "Id", "Type", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Languages, "Id", "PublicationLanguage", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Users, "Id", "Forename", bookStatus.Id);
            return View(bookStatus);
        }

        // POST: BookStatusBookStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookStatusEdit([Bind(Include = "Book,CoverType,Edition,FileExtension,Language,User,Id,IsAvailable,IsMissing,UserName,StartDate,EndDate")] BookStatus bookStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookStatus).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a BookStatus record");
                return RedirectToAction("BookStatusIndex");
            }
            ViewBag.Id = new SelectList(db.CoverTypies, "Id", "Id", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace", bookStatus.Id);
            ViewBag.Id = new SelectList(db.FileExtensions, "Id", "Type", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Languages, "Id", "PublicationLanguage", bookStatus.Id);
            ViewBag.Id = new SelectList(db.Users, "Id", "Forename", bookStatus.Id);
            DisplayErrorMessage();
            return View(bookStatus);
        }

        // GET: BookStatus/BookStatusDelete/5
        public ActionResult BookStatusDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookStatus bookStatus = db.BookStatuses.Find(id);
            if (bookStatus == null)
            {
                return HttpNotFound();
            }
            return View(bookStatus);
        }

        // POST: BookStatus/BookStatusDelete/5
        [HttpPost, ActionName("BookStatusDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BookStatusDeleteConfirmed(int id)
        {
            BookStatus bookStatus = db.BookStatuses.Find(id);
            db.BookStatuses.Remove(bookStatus);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a BookStatus record");
            return RedirectToAction("BookStatusIndex");
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
