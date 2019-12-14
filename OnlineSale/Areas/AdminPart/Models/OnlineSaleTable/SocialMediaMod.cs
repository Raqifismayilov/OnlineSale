using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class SocialMediaMod
    {
        public short Id { get; set; }
        public string SocName { get; set; }
        public string SocPath { get; set; }
        public SocialMediaMod() { }
        public SocialMediaMod(string socName, string socPath)
        {
            SocName = socName;
            SocPath = socPath;
        }
    }
}