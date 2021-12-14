using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class A_PostQuestionRecords
    {
        public A_PostQuestionRecords(int get_num, string get_type, string get_code, string get_answer, Boolean get_Corrects)
        {
            Q_num = get_num;
            Qtype = get_type;
            QCode = get_code;
            S_ans = get_answer;
            Judge = get_Corrects;
        }

        public int Q_num { get; set; }//答題順序

        public string Qtype { get; set; }//題目種類

        public string QCode { get; set; }//題庫編號


        public string S_ans { get; set; }//學生作答的答案

        public Boolean Judge { get; set; }//正確與否 O X





    }
}