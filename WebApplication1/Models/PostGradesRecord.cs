using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PostGradesRecord
    {
        public PostGradesRecord(string get_StudentCode,int get_grades,int get_Corrects,int get_Incorrects,string get_Playtime,string get_Records)
        {
            StudentCode = get_StudentCode;
            grades = get_grades;
            Corrects = get_Corrects;
            Incorrects = get_Incorrects;
            PlayTime = get_Playtime;
            Records = get_Records;
        }

        public string StudentCode { get; set; }//學生代碼

        public int grades { get; set; }

        public int Corrects { get; set; }

        public int Incorrects { get; set; }
        public string PlayTime { get; set; }

        public string Records { get; set; }
    }
}