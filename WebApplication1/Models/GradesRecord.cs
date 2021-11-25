using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GradesRecord
    {
        public GradesRecord(int get_id, string get_StudentCode, int get_grades, int get_Corrects, int get_Incorrects, string get_PlayTime, List<QuestionRecord> data)
        {
            id = get_id;////Unity端省略
            StudentCode = get_StudentCode;
            grades = get_grades;
            Corrects = get_Corrects;
            Incorrects = get_Incorrects;
            PlayTime = get_PlayTime;
            Records = data;
        }

        public int id { get; set; }//Unity端省略 預設為0

        public string StudentCode { get; set; }

        public int grades { get; set; }

        public int Corrects { get; set; }

        public int Incorrects { get; set; }
        public string PlayTime { get; set; }

        public List<QuestionRecord> Records { get; set; }



    }
}