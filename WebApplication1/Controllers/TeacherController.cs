using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{

    
    public class TeacherController : ApiController
    {
        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);

        
        //api/Teacher/Post
        public IHttpActionResult Post([FromBody]TeacherAccount Teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            string insert= "insert into TeacherAccount (Accountname,Password,classcode,username) values(@Accountname,@Password,@classcode,@username)";
            SqlCommand cmd = new SqlCommand(insert, mycon);

            cmd.Parameters.Add("@Accountname", SqlDbType.VarChar, 200).Value = Teacher.Accountname;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = Teacher.Password;
            cmd.Parameters.Add("@classcode",SqlDbType.VarChar, 200).Value = Teacher.classcode;
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 200).Value = Teacher.username;
            cmd.CommandType = CommandType.Text;

            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();

            return Ok();
        }

        



    }

    
}
