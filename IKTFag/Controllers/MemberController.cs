using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace IKTFag.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            // Redirect to login if username session is not set
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                return RedirectToAction("Login");
            }

            ViewData["Flash"] = TempData["Flash"];
            ViewData["Username"] = HttpContext.Session.GetString("username");
            ViewData["Message"] = "Hello, C#";

            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Request.Method == "POST")
            {
                // TODO login logic
                string username = "bope1305";
                string flash = String.Format("Welcome, {0}", username);

                // Set username session
                HttpContext.Session.SetString("username", username);

                TempData["Flash"] = flash;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
