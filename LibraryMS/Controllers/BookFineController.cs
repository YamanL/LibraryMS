using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer;

namespace LibraryMS.Controllers
{
    public class BookFineController : Controller
    {
        private LibraryMSDbEntities db = new LibraryMSDbEntities();
        // GET: BookFine
        public ActionResult PendingFine()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var pendingfine = db.BookFineTables.Where(f => f.ReceiveAmount == 0);
            return View(pendingfine.ToList());
        }

        public ActionResult FineHistory()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var finehistory = db.BookFineTables.Where(f => f.ReceiveAmount > 0);
            return View(finehistory.ToList());
        }

        public ActionResult SubmitFine(int? id)
        {
            var fine = db.BookFineTables.Find(id);
            fine.ReceiveAmount = fine.FineAmount;
            fine.FineDate = DateTime.Now;
            db.Entry(fine).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PendingFine");
        }
    }
}