using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace LibraryMS.Controllers
{
    public class HomeController : Controller
    {
        private LibraryMSDbEntities db = new LibraryMSDbEntities();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            try
            {
                if (username != null && password != null)
                {
                    var finduser = db.UserTables.Where(u => u.UserName == username && u.Password == password && u.IsActive == true).ToList();
                    if (finduser.Count() == 1)
                    {
                        Session["UserID"] = finduser[0].UserID;
                        Session["UserTypeID"] = finduser[0].UserTypeID;
                        Session["UserName"] = finduser[0].UserName;
                        Session["Password"] = finduser[0].Password;
                        Session["EmployeeID"] = finduser[0].EmployeeID;

                        string url = string.Empty;
                        if (finduser[0].UserTypeID == 2)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeID == 3)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeID == 4)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeID == 1)
                        {
                            url = "About";
                        }
                        else
                        {
                            url = "About";
                        }
                        return RedirectToAction(url);
                    }
                    else
                    {
                        Session["UserID"] = string.Empty;
                        Session["UserTypeID"] = string.Empty;
                        Session["UserName"] = string.Empty;
                        Session["Password"] = string.Empty;
                        Session["EmployeeID"] = string.Empty;
                        ViewBag.Message = "UserName and Password is Incorrect!";
                    }
                }
                else
                {
                    Session["UserID"] = string.Empty;
                    Session["UserTypeID"] = string.Empty;
                    Session["UserName"] = string.Empty;
                    Session["Password"] = string.Empty; 
                    Session["EmployeeID"] = string.Empty;
                    ViewBag.Message = "Some unexpected issue is occured Please Try Again!";
                }
            }
            catch (Exception ex)
            {
                Session["UserID"] = string.Empty;
                Session["UserTypeID"] = string.Empty;
                Session["UserName"] = string.Empty;
                Session["Password"] = string.Empty;
                Session["EmployeeID"] = string.Empty;
               // ViewBag.Message = "Some unexpected issue is occured Please Try Again!";
                ViewBag.Message = ex.Message;
            }
            return View("Login");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            int usertypeid = 0;
            if (Session["UserTypeID"] != null)
            {
                usertypeid = Convert.ToInt32(Convert.ToString(Session["UserTypeID"]));
            }
            if (usertypeid == 2)

            {
                return RedirectToAction("Index", "ReserveBook", null);
            }
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.message = "Your Contact Page";

            return View();
        }
        public ActionResult Logout()
{
            Session["UserID"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            Session["EmployeeID"] = string.Empty;
            return RedirectToAction("Login");
        }
}
}