using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherDeleteController : ApiController
    {
        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);
        public IHttpActionResult Post([FromBody] int t1)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            string delete = "delete from TeacherAccount where Id=@id";
            SqlCommand cmd = new SqlCommand(delete, mycon);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = t1;
            cmd.CommandType = CommandType.Text;

            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();

            return Ok();
        }
    }
}