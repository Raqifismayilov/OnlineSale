using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class AboutView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public List<AboutMod> AboutList { get; set; }
        public AboutMod About { get; set; }
        public AboutView() { }
        public AboutView(List<AdminPanel> adminPanel, List<AboutMod> aboutLst, AboutMod about)
        {
            AdminPanel = adminPanel;
            AboutList = aboutLst;
            About = about;
        }
    }
}