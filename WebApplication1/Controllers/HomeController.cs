using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult FormText()
        {
            return View();
        }

        
        public ActionResult Getpostdata()
        {
           
            using (var client = new HttpClient())
            {
                
                TeacherAccount t1 = new TeacherAccount(50, "Testaccount4","94879487","104","LF");
                client.BaseAddress = new Uri("https://localhost:44368/api/Teacher");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TeacherAccount>("Teacher", t1);
                

                var result = postTask.GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("FormText");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");


            return RedirectToAction("FormText");
        }

        public ActionResult DeleteData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/TeacherDelete");

                //HTTP POST
                //TeacherAccount t1 = new TeacherAccount(7, "Testaccount4", "94879487", "104", "LF");
                var postTask = client.PostAsJsonAsync<int>("TeacherDelete",11);


                var result = postTask.GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("FormText");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return RedirectToAction("FormText");
        }



    }
}
