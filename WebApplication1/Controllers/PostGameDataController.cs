using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PostGameDataController : ApiController
    {
        public IHttpActionResult Post()
        {

            return Ok();
        }
    }

    public class PostGameRecordsController : ApiController
    {

        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);
        public IHttpActionResult Post([FromBody] GameRecords gamerecords)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            string insert = "insert into TeacherAccount (Accountname,Password,classcode,username) values(@Accountname,@Password,@classcode,@username)";
            SqlCommand cmd = new SqlCommand(insert, mycon);

            

            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();


            return Ok();
        }
    }
}
