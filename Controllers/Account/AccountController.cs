using Hospital_Information_System.Models.Account;
using Hospital_Information_System_Business.BizHandler;
using Hospital_Information_System_Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Information_System.Controllers.Account
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            EmployeeHandler employeeHandler = new EmployeeHandler();
            if (employeeHandler.isAuthenticate(m.UserName, m.Password))
            {
                if (m.RememberMe == true)
                {
                    HttpCookie cookie = new HttpCookie("c");
                    cookie.Expires = DateTime.Today.AddDays(1);
                    cookie.Values.Add("UserName", m.UserName);
                    cookie.Values.Add("Password", m.Password);
                    Response.SetCookie(cookie);
                }
                Session.Add("CurrentUser", m.UserName);
                return RedirectToAction("Index", "Admin");

            }
            else 
            {
                TempData["Message"] = "User Name and Password are Not Macthed";
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cook = Request.Cookies["c"];
            if (cook != null)
            {
                cook.Expires = DateTime.Now;
                Response.SetCookie(cook);
            }
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult RestrictAccess()
        {
            string userName = Convert.ToString(Session["CurrentUser"]);

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

    }
}
