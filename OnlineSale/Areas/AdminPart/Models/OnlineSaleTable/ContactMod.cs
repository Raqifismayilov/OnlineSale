using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class ContactMod
    {
        public short Id { get; set; }
        public string Number { get; set; }
        public string MobNumber { get; set; }
        public string Email { get; set; }
        public string MapPath { get; set; }
        public string OurAddress { get; set; }
        public ContactMod()
        { }
        public ContactMod(string num, string mob, string email, string map, string ourAddress)
        {
            Number = num;
            MobNumber = mob;
            Email = email;
            MapPath = map;
            OurAddress = ourAddress;
        }

    }
}