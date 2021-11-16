using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TeacherAccount
    {
        public TeacherAccount()
        {
        }

        public TeacherAccount(int post_id,string post_Accountname,string post_password,string post_classcode,string post_username)
        {
            Id = post_id;
            Accountname = post_Accountname;
            Password = post_password;
            classcode = post_classcode;
            username = post_username;
        }

        public void AddScore(float Scores)
        {
            Score = Scores;
        }

        public int Id { get; set; }
        public string Accountname { get; set; }

        public string Password { get; set; }

        public string classcode { get; set; }
        public string username { get; set; }

        public float Score { get; set; }
    }
}