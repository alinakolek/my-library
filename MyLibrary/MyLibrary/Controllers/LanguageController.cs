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
    public class LanguageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Language/LanguageIndex
        public ActionResult LanguageIndex()
        {
            var language = db.Languages.Include(l => l.BookStatus);
            return View(language.ToList());
        }

        /*
        // GET: Language/LanguageDetails/5
        public ActionResult LanguageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }
        */

        // GET: Language/LanguageCreate
        public ActionResult LanguageCreate()
        {
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName");
            return View();
        }

        // POST: Language/LanguageCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageCreate([Bind(Include = "BookStatus,LanguageList,Id,PublicationLanguage,OriginalLanguage")] Language language)
        {
            if (ModelState.IsValid)
            {
                db.Languages.Add(language);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Language record");
                return RedirectToAction("LanguageIndex");
            }

            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", language.Id);
            DisplayErrorMessage();
            return View(language);
        }

        // GET: Language/LanguageEdit/5
        public ActionResult LanguageEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", language.Id);
            return View(language);
        }

        // POST: LanguageLanguage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageEdit([Bind(Include = "BookStatus,LanguageList,Id,PublicationLanguage,OriginalLanguage")] Language language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(language).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Language record");
                return RedirectToAction("LanguageIndex");
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", language.Id);
            DisplayErrorMessage();
            return View(language);
        }

        // GET: Language/LanguageDelete/5
        public ActionResult LanguageDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: Language/LanguageDelete/5
        [HttpPost, ActionName("LanguageDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageDeleteConfirmed(int id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Language record");
            return RedirectToAction("LanguageIndex");
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
