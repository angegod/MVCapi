using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

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
                List<PostQuestionRecord> list1 = new List<PostQuestionRecord>();

                list1.Add(new PostQuestionRecord(1,"Choose", "110101_5C","A",true));
                list1.Add(new PostQuestionRecord(2, "Choose", "110101_33C", "C", true));
                list1.Add(new PostQuestionRecord(3, "Yesno", "110101_24Y", "O", false));

                string q = JsonConvert.SerializeObject(list1);

                PostGradesRecord p1=new PostGradesRecord("udzwt3fa",80,15,5,"06:50:00",q);

                string data = JsonConvert.SerializeObject(p1);
                //HttpContent Postdata = new StringContent(data);

                TempData["data"] = data;
                //HTTP POST
                var postTask =  client.GetAsync("http://localhost:7700/api/PostGameData/DataPost?getdata="+data);
                
;               
                var result = postTask.GetAwaiter().GetResult();
                TempData["Errors"] = result.ToString();
                if (result.ToString()=="Success")
                {
                    return RedirectToAction("FormText");
                }
                else
                {
                    TempData["Errors"] = result.ToString();
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");


            return RedirectToAction("FormText");
        }

        public ActionResult DeleteData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://203.64.134.239:7700/api/TeacherDelete");

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

        public ActionResult FormDataTest()//測試用 之後會刪掉
        {
            List<TeacherAccount> list1 = new List<TeacherAccount>() {
                new TeacherAccount(){Id=1,AccountName="Wolfking",classcode="101",Password="20200708",username="下野"},
                new TeacherAccount(){Id=2,AccountName="Killer",classcode="102",Password="20200509",username="安哥"},
                new TeacherAccount(){Id=3,AccountName="Ramon",classcode="103",Password="20200123",username="鐳門"},
                new TeacherAccount(){Id=4,AccountName="TheSun",classcode="104",Password="20210926",username="聖文斯"},
            };

           


            string JsonData = JsonConvert.SerializeObject(list1);
            TempData["JsonData"] = JsonData;


            return RedirectToAction("FormText");
        }



    }
}
