using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IKTFag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;

            psi.Arguments = "Get-Host";
            Process p = Process.Start(psi);
            string strOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            Console.WriteLine(strOutput);

            ViewData["vmware"] = strOutput;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
