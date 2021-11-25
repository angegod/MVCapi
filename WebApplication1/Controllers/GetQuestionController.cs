using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using WebApplication1.Models;
using Newtonsoft.Json;
using System.Data;

namespace WebApplication1.Controllers
{
    public class GetQuestionChooseController : ApiController
    {


        // GET api/GetQuestionYesno/Get?classcode=101
        [Route("api/GetQuestionChoose/Get")]
        [HttpGet]
        public string Get(string classcode)
        {
            string login = "select * from typechoose where classcode=@classcode";//connection
            string conn = "Server=TR\\SQLEXPRESS;Database=question;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";

            SqlConnection mycon = new SqlConnection(conn);
           
            mycon.Open();
            SqlCommand mycom = new SqlCommand(login, mycon);
            mycom.Parameters.Add("@classcode", SqlDbType.VarChar, 200).Value = classcode;
                
            SqlDataReader mydr1 = mycom.ExecuteReader();

            List<Questionchoose> QuestionList = new List<Questionchoose>();
            while (mydr1.HasRows)
            {
                while (mydr1.Read())
                {
                    int id = mydr1.GetInt32(0);
                    string question = mydr1.GetString(1);
                    string optionsA = mydr1.GetString(2);
                    string optionsB = mydr1.GetString(3);
                    string optionsC = mydr1.GetString(4);
                    string answer = mydr1.GetString(5);
                    int difficulty = mydr1.GetInt32(7);
                    string detailed = mydr1.GetString(8);


                    QuestionList.Add(new Questionchoose(id, question, optionsA, optionsB, optionsC, answer, detailed, difficulty));
                }
                mydr1.NextResult();

            }
            mycon.Close();
            string Jsondata = JsonConvert.SerializeObject(QuestionList);

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

    public class GetQuestionYesnoController : ApiController
    { 
        // GET api/values/classcode=101
        [Route("api/GetQuestionYesno/Get")]
        [HttpGet]
        public string Get(string classcode)
        {
            string login = "select * from typeyesno where classcode=@classcode";//connection
            string conn = "Server=TR\\SQLEXPRESS;Database=question;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";

            SqlConnection mycon = new SqlConnection(conn);

            mycon.Open();
            SqlCommand mycom = new SqlCommand(login, mycon);
            mycom.Parameters.Add("@classcode", SqlDbType.VarChar, 200).Value = classcode;
            SqlDataReader mydr = mycom.ExecuteReader();

            List<Questionyesno> QuestionList = new List<Questionyesno>();

            while (mydr.HasRows)
            {
                while (mydr.Read())
                {
                    int id = mydr.GetInt32(0);
                    string question = mydr.GetString(1);
                    string answer = mydr.GetString(2);
                    int difficulty = mydr.GetInt32(4);
                    string detailed = mydr.GetString(5);

                    QuestionList.Add(new Questionyesno(id, question, answer, detailed, difficulty));
                }
                mydr.NextResult();
            }
            string Jsondata = JsonConvert.SerializeObject(QuestionList);

            return Jsondata;
        }

        // POST api/values
        

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
