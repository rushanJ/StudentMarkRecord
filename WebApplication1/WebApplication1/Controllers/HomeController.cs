using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminDashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LecturerDashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Auth(String email , String password)
        {
            ViewBag.Message = "Your contact page.";

             HomeModule homeModule= new  HomeModule();

             homeModule.setEmail(email);
             homeModule.setPassword(password);


             if (homeModule.auth())
             {
                if (homeModule.getRole()=="ADMIN") return RedirectToAction("AdminDashboard", "Home");
                else return RedirectToAction("LecturerDashboard", "Home");
            }
             else return RedirectToAction("Index", "Home");
        }
    }
}