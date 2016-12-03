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
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Category/CategoryIndex
        public ActionResult CategoryIndex()
        {
            var category = db.Categories.Include(c => c.Book);
            return View(category.ToList());
        }

        /*
        // GET: Category/CategoryDetails/5
        public ActionResult CategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        */

        // GET: Category/CategoryCreate
        public ActionResult CategoryCreate()
        {
            ViewBag.Id = new SelectList(db.Books, "Id", "Title");
            return View();
        }

        // POST: Category/CategoryCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryCreate([Bind(Include = "Book,Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Category record");
                return RedirectToAction("CategoryIndex");
            }

            ViewBag.Id = new SelectList(db.Books, "Id", "Title", category.Id);
            DisplayErrorMessage();
            return View(category);
        }

        // GET: Category/CategoryEdit/5
        public ActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Books, "Id", "Title", category.Id);
            return View(category);
        }

        // POST: CategoryCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryEdit([Bind(Include = "Book,Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Category record");
                return RedirectToAction("CategoryIndex");
            }
            ViewBag.Id = new SelectList(db.Books, "Id", "Title", category.Id);
            DisplayErrorMessage();
            return View(category);
        }

        // GET: Category/CategoryDelete/5
        public ActionResult CategoryDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/CategoryDelete/5
        [HttpPost, ActionName("CategoryDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryDeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Category record");
            return RedirectToAction("CategoryIndex");
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
