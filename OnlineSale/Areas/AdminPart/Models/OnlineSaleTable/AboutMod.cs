using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class AboutMod
    {
        public short Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public AboutMod() { }
        public AboutMod(string h, string b, string f)
        {
            Header = h;
            Body = b;
            Footer = f;
        }
    }
}