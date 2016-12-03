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
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books/BooksIndex
        public ActionResult BooksIndex()
        {
            var book = db.Books.Include(b => b.Category).Include(b => b.Description);
            return View(book.ToList());
        }

        /*
        // GET: Books/BooksDetails/5
        public ActionResult BooksDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        */

        // GET: Books/BooksCreate
        public ActionResult BooksCreate()
        {
            ViewBag.Id = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Id = new SelectList(db.Descriptions, "Id", "DescriptionContent");
            return View();
        }

        // POST: Books/BooksCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BooksCreate([Bind(Include = "Author,BookStatuses,Category,Description,Tags,Id,Title,PageNumber,BookCoverImage")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Book record");
                return RedirectToAction("BooksIndex");
            }

            ViewBag.Id = new SelectList(db.Categories, "Id", "Name", book.Id);
            ViewBag.Id = new SelectList(db.Descriptions, "Id", "DescriptionContent", book.Id);
            DisplayErrorMessage();
            return View(book);
        }

        // GET: Books/BooksEdit/5
        public ActionResult BooksEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Categories, "Id", "Name", book.Id);
            ViewBag.Id = new SelectList(db.Descriptions, "Id", "DescriptionContent", book.Id);
            return View(book);
        }

        // POST: BooksBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BooksEdit([Bind(Include = "Author,BookStatuses,Category,Description,Tags,Id,Title,PageNumber,BookCoverImage")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Book record");
                return RedirectToAction("BooksIndex");
            }
            ViewBag.Id = new SelectList(db.Categories, "Id", "Name", book.Id);
            ViewBag.Id = new SelectList(db.Descriptions, "Id", "DescriptionContent", book.Id);
            DisplayErrorMessage();
            return View(book);
        }

        // GET: Books/BooksDelete/5
        public ActionResult BooksDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/BooksDelete/5
        [HttpPost, ActionName("BooksDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult BooksDeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Book record");
            return RedirectToAction("BooksIndex");
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
