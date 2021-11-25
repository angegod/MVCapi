using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PostQuestionRecord
    {
        public int Question_num { get; set; }//答題順序

        public string Questiontype { get; set; }//題目種類

        public string QuestionCode { get; set; }//題庫編號

        public string Student_answer { get; set; }//學生作答的答案

        public Boolean Corrects { get; set; }//正確與否 O X
    }
}