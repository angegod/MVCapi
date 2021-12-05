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

namespace WebApplication1.Controllers
{
    public class StudentController : ApiController
    {
        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);


        [Route("api/Student/Confirm")]
        [HttpGet]

        public string Confirm(string username,string password)
        {
            string Result = "null";
            string login = "select * from Account where Accountname=@Accountname";//connection
            SqlCommand cmd = new SqlCommand(login, mycon);

            cmd.Parameters.Add("@Accountname", SqlDbType.VarChar, 200).Value = username;
            

            mycon.Open();
            SqlDataReader mydr = cmd.ExecuteReader();
            while (mydr.HasRows)
            {
                while (mydr.Read())
                {
                    string get_Password = mydr.GetString(2);
                    if (string.Equals(get_Password, password))
                    {
                        int get_id = mydr.GetInt32(0);
                        string get_AccountName = mydr.GetString(1);
                        string get_classcode = mydr.GetString(3);
                        string get_Username = mydr.GetString(4);
                        string get_identifiedcode = mydr.GetString(5);

                        Student st = new Student(get_id, get_AccountName, get_classcode, get_Username, get_identifiedcode);
                        Result = JsonConvert.SerializeObject(st);
                    }

                    
                }
                mydr.NextResult();
            }
            mydr.Close();

            if (string.Equals(Result, "null"))
            {
                return Result;
            }
            else
            {
                return Result;
            }
            
        }


    }
}
