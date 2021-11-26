using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PostGradesRecord
    {
        public int id { get; set; }//Unity端省略 預設為0

        public string StudentCode { get; set; }

        public int grades { get; set; }

        public int Corrects { get; set; }

        public int Incorrects { get; set; }
        public string PlayTime { get; set; }

        public List<QuestionRecord> Records { get; set; }
    }
}