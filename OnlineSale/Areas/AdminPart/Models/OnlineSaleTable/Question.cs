using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class Question
    {
        public short Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string QuestnionBody { get; set; }
        public Question() { }
        public Question(string userName, string email, string questionBody)
        {
            UserName = userName;
            Email = email;
            QuestnionBody = questionBody;
        }
    }
}