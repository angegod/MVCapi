using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PostQuestionRecord
    {
        public PostQuestionRecord(int get_num,string get_type,string get_code,string get_answer,Boolean get_Corrects)
        {
            Question_num = get_num;
            Questiontype = get_type;
            QuestionCode = get_code;
            Student_answer = get_answer;
            Corrects = get_Corrects;
        }

        public int Question_num { get; set; }//答題順序

        public string Questiontype { get; set; }//題目種類

        public string QuestionCode { get; set; }//題庫編號

       
        public string Student_answer { get; set; }//學生作答的答案

        public Boolean Corrects { get; set; }//正確與否 O X

    }
}