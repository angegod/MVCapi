using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebApplication1.Controllers
{

    
    public class TeacherController : ApiController
    {
        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);

        [HttpPost]
        [Route("api/Teacher/Post")]
        public HttpResponseMessage Post( string data)
        {
            try
            {
                TeacherAccount Teacher = JsonConvert.DeserializeObject<TeacherAccount>(data);

                string insert = "insert into TeacherAccount (Accountname,Password,classcode,username) values(@Accountname,@Password,@classcode,@username)";
                SqlCommand cmd = new SqlCommand(insert, mycon);

                cmd.Parameters.Add("@Accountname", SqlDbType.VarChar, 200).Value = Teacher.AccountName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = Teacher.Password;
                cmd.Parameters.Add("@classcode", SqlDbType.VarChar, 200).Value = Teacher.classcode;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 200).Value = Teacher.username;
                cmd.CommandType = CommandType.Text;

                mycon.Open();
                cmd.ExecuteNonQuery();
                mycon.Close();

                return Request.CreateResponse(HttpStatusCode.OK, "true");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed");
            }
        }
            

        



    }

    
}
