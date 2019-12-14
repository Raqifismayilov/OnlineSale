using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class UserMod
    {
        public int Id { get; set; }
        public byte[] Hid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] SaltHash { get; set; }
        public short UserTypeId { get; set; }

        public UserMod() { }
        public UserMod(string fName, string lName, string uName, string email, short usrTypeId)
        {
            Firstname = fName;
            Lastname = lName;
            Username = uName;
            Email = email;
            UserTypeId = usrTypeId;
        }
    }
}