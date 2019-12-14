using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.UserSign
{
    public class UserSignIn
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] HashSalt { get; set; }
        public byte[] HashPasword { get; set; }
        public UserSignIn() { }
        public UserSignIn(string usNm, string pwd)
        {
            Username = usNm.Trim();
            Password = pwd.Trim();
        }

    }
}