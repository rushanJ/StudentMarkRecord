using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        student_dataEntities2 context = new student_dataEntities2();

        HomeModule homeModule = new HomeModule();
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
       
            homeModule.LecModuleList(Session["id"].ToString());
            var viewModel = new LecModuleViewModel
            {
                HomeModule = homeModule,
                LecModule = homeModule.lecModule
            };

            return View(viewModel);
        }

        public ActionResult LectureDashboard()
        {
            ViewBag.Message = "Your contact page.";

            homeModule.LecStatModuleList(Session["id"].ToString());
            var viewModel = new LecStatModuleViewModel
            {
                HomeModule = homeModule,
                LecModule = homeModule.lecStatModule
            };

            return View(viewModel);
        }

        public ActionResult Auth(String email , String password)
        {
            ViewBag.Message = "Your contact page.";

           //  HomeModule homeModule= new  HomeModule();

             homeModule.setEmail(email);
             homeModule.setPassword(password);


             if (homeModule.auth())
             {

                Session["id"] = homeModule.getId();
                if (homeModule.getRole()=="ADMIN") return RedirectToAction("AdminDashboard", "Home");
                else return RedirectToAction("LecturerDashboard", "Home");
            }
             else return RedirectToAction("Index", "Home");
        }
       
        

    }
}