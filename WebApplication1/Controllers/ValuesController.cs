using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public string  Get(int id)
        {
            string login = "select * from TeacherAccount";//connection
           
            mycon.Open();
            SqlCommand mycom = new SqlCommand(login, mycon);

            SqlDataReader mydr = mycom.ExecuteReader();
            
            List<TeacherAccount> TeacherList = new List<TeacherAccount>();
            while (mydr.HasRows)
            {
                while (mydr.Read())
                {
                    int getid = mydr.GetInt32(0);
                    string confirmName = mydr.GetString(1);
                    string confirmPwd = mydr.GetString(2);
                    string classCode = mydr.GetString(3);
                    string getUserName = mydr.GetString(4);

                    TeacherList.Add(new TeacherAccount(getid, confirmName, confirmPwd, classCode, getUserName));
                   
                }
                mydr.NextResult();

            }
            mycon.Close();
            string Jsondata= JsonConvert.SerializeObject(TeacherList);

            return Jsondata;
        }

        

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {

        }

       

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
