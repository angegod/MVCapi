using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace WebApplication1.Models
{

    public class Question
    {

    }

    public class Questionchoose
    {

        public Questionchoose(int id1,string question1,string optionsA1,string optionsB1,string optionsC1,string answer1,string detailed1,int  difficulty1)
        {
            id = id1;
            question = question1;
            optionsA = optionsA1;
            optionsB = optionsB1;
            optionsC = optionsC1;
            answer = answer1;
            detailed = detailed1;
            difficulty = difficulty1;
        }

        public int id { get; set; }
        public string question { get; set; }

        public string optionsA { get; set; }

        public string optionsB { get; set; }

        public string optionsC { get; set; }

        public string answer { get; set; }

        public string detailed { get; set; }

        public int  difficulty { get; set; }

        

    }
    public class Questionyesno
    {
        public Questionyesno(int id1, string question1, string answer1, string detailed1, int difficulty1)
        {
            id = id1;
            question = question1;
            answer = answer1;
            detailed = detailed1;
            difficulty = difficulty1;

        }
        public int id { get; set; }

        public string question { get; set; }

        public string answer { get; set; }

        public string detailed { get; set; }

        public int  difficulty { get; set;}
    }
}