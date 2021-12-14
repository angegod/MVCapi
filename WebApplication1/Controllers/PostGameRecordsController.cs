using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class PostGameRecordsController : ApiController
    {
        public static string conn = "Server=TR\\SQLEXPRESS;Database=TheRich;uid=ange;pwd=ange0909;Trusted_Connection=True;MultipleActiveResultSets=True;";
        SqlConnection mycon = new SqlConnection(conn);

        [Route("api/PostGameRecords/")]
        
        [HttpPost]
        public string Post([FromBody]string Postdata)
        {
            if (string.IsNullOrEmpty(Postdata))//null 偵測
            {
                return "Nodata can process";
            }
            try
            { 

                PostGradesRecord data = JsonConvert.DeserializeObject<PostGradesRecord>(Postdata);

                string insert = "insert into Record (Studentcode,Grades,Corrects,Incorrects,Playtime,GameRecords) values(@Studentcode,@Grades,@Corrects,@Incorrects,@Playtime,@GameRecords)";
                SqlCommand cmd = new SqlCommand(insert, mycon);

                cmd.Parameters.Add("@Studentcode", SqlDbType.VarChar, 200).Value = data.StudentCode;
                cmd.Parameters.Add("@Grades", SqlDbType.Int).Value = data.grades;
                cmd.Parameters.Add("@Corrects", SqlDbType.Int).Value = data.Corrects;
                cmd.Parameters.Add("@Incorrects", SqlDbType.Int).Value = data.Incorrects;
                cmd.Parameters.Add("@Playtime", SqlDbType.Time).Value = TimeSpan.Parse(data.PlayTime);//時間轉換
                cmd.Parameters.Add("@GameRecords", SqlDbType.VarChar).Value = data.Records;

                cmd.CommandType = CommandType.Text;


                mycon.Open();
                cmd.ExecuteNonQuery();
                mycon.Close();
                return  "OK";
            }
            catch(Exception e)
            {
                return Postdata+" &  "+e.ToString();
            }

        }

        [Route("api/PostGameRecords/DataPost")]
        [HttpGet]
        public string DataPost(string getdata)
        {

            try
            {
                PostGradesRecord data = JsonConvert.DeserializeObject<PostGradesRecord>(getdata);

                string insert = "insert into Record (Studentcode,Grades,Corrects,Incorrects,Playtime,GameRecords) values(@Studentcode,@Grades,@Corrects,@Incorrects,@Playtime,@GameRecords)";
                SqlCommand cmd = new SqlCommand(insert, mycon);

                cmd.Parameters.Add("@Studentcode", SqlDbType.VarChar, 200).Value = data.StudentCode;
                cmd.Parameters.Add("@Grades", SqlDbType.Int).Value = data.grades;
                cmd.Parameters.Add("@Corrects", SqlDbType.Int).Value = data.Corrects;
                cmd.Parameters.Add("@Incorrects", SqlDbType.Int).Value = data.Incorrects;
                cmd.Parameters.Add("@Playtime", SqlDbType.Time).Value = TimeSpan.Parse(data.PlayTime);//時間轉換
                cmd.Parameters.Add("@GameRecords", SqlDbType.VarChar).Value = data.Records;

                cmd.CommandType = CommandType.Text;


                mycon.Open();
                cmd.ExecuteNonQuery();
                mycon.Close();
                return "Success";
            }
            catch (Exception e)
            {
                return "Errors";
            }
        }







    }
}
