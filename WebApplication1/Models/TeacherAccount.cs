using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TeacherAccount
    {
        public TeacherAccount(int id, string name, string password, string classCodes)
        {
            Id = id;
            AccountName = name;
            Password = password;
            classcode = classCodes;
        }
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }

        public string classcode { get; set; }
    }
}