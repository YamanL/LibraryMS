using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Controllers
{
    public class ReserveBookController : Controller
    {
        private LibraryMSDbEntities db = new LibraryMSDbEntities();
        // GET: ReserveBook
        public string Message { get; set; }
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = Message;
            Message = string.Empty;
            var books = db.BookTables.ToList();
            return View(books);
        }
        public ActionResult ReserveBook(int? id)
        {
            var book = db.BookTables.Find(id);
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int employeeid = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
            var issueBookTable = new IssueBookTable()
            {
                BookID = book.BookID,
                Description = "Reserve Request!",
                EmployeeID = employeeid,
                IssueCopies =  1,
                IssueDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(2),
                Status = false,
                ReserveNoOfCopies = true,
                UserID  = userid

            };
            issueBookTable.UserID = userid;
            if (ModelState.IsValid)
            {
                var find = db.IssueBookTables.Where(b => b.ReturnDate < DateTime.Now && b.BookID == issueBookTable.BookID && (b.Status == true || b.ReserveNoOfCopies == true)).ToList();
                int issuebooks = 0;
                foreach (var item in find)
                {
                    issuebooks = issuebooks + item.IssueCopies;
                }

                var stockbooks = db.BookTables.Where(b => b.BookID == issueBookTable.BookID).FirstOrDefault();
                if ((issuebooks == stockbooks.TotalCopies) || (issuebooks + issueBookTable.IssueCopies > stockbooks.TotalCopies))
                {
                    Message = "Stock is Empty!";
                    return RedirectToAction("Index");
                }
                db.IssueBookTables.Add(issueBookTable);
                db.SaveChanges();
                Message = "Book Issued Successfully!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


    }
}