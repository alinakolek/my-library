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
    public class LanguageListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LanguageList/LanguageListIndex
        public ActionResult LanguageListIndex()
        {
            return View(db.LanguageLists.ToList());
        }

        /*
        // GET: LanguageList/LanguageListDetails/5
        public ActionResult LanguageListDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageList languageList = db.LanguageLists.Find(id);
            if (languageList == null)
            {
                return HttpNotFound();
            }
            return View(languageList);
        }
        */

        // GET: LanguageList/LanguageListCreate
        public ActionResult LanguageListCreate()
        {
            return View();
        }

        // POST: LanguageList/LanguageListCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageListCreate([Bind(Include = "Languages,Id,Name")] LanguageList languageList)
        {
            if (ModelState.IsValid)
            {
                db.LanguageLists.Add(languageList);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a LanguageList record");
                return RedirectToAction("LanguageListIndex");
            }

            DisplayErrorMessage();
            return View(languageList);
        }

        // GET: LanguageList/LanguageListEdit/5
        public ActionResult LanguageListEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageList languageList = db.LanguageLists.Find(id);
            if (languageList == null)
            {
                return HttpNotFound();
            }
            return View(languageList);
        }

        // POST: LanguageListLanguageList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageListEdit([Bind(Include = "Languages,Id,Name")] LanguageList languageList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageList).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a LanguageList record");
                return RedirectToAction("LanguageListIndex");
            }
            DisplayErrorMessage();
            return View(languageList);
        }

        // GET: LanguageList/LanguageListDelete/5
        public ActionResult LanguageListDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageList languageList = db.LanguageLists.Find(id);
            if (languageList == null)
            {
                return HttpNotFound();
            }
            return View(languageList);
        }

        // POST: LanguageList/LanguageListDelete/5
        [HttpPost, ActionName("LanguageListDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageListDeleteConfirmed(int id)
        {
            LanguageList languageList = db.LanguageLists.Find(id);
            db.LanguageLists.Remove(languageList);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a LanguageList record");
            return RedirectToAction("LanguageListIndex");
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
