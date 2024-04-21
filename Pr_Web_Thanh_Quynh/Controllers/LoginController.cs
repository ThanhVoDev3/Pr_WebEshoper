using Pr_Web_Thanh_Quynh.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pr_Web_Thanh_Quynh.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (string Acc , string Pass) 
        {
            bool isAuthentic = (Acc != null && Pass != null && Acc.ToLower().Equals("admin") && Pass.Equals("123456"));
            if (isAuthentic)
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            return View();
        }
    }
}