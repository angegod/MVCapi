using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {

        public Student(int id, string name, string code, string User, string IdCode)
        {
            Id = id;
            AccountName = name;
            classcode = code;
            Username = User;
            IdentifiedCode = IdCode;
        }

        public int Id { get; set; }
        public string AccountName { get; set; }
        public string classcode { get; set; }

        public string Username { get; set; }

        public string IdentifiedCode { get; set; }


    }
}