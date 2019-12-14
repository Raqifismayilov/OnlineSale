using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class FooterMod
    {
        public short Id { get; set; }
        public string Copyright { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public FooterMod() { }
        public FooterMod(string cop, string head, string body, string ft)
        {
            Copyright = cop;
            Header = head;
            Body = body;
            Footer = ft;
        }
    }
}