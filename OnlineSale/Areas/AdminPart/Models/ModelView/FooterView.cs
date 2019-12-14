using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class FooterView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public List<FooterMod> FooterList { get; set; }
        public FooterMod Footer { get; set; }
        public FooterView() { }
        public FooterView(List<AdminPanel> admPanel, List<FooterMod> ftrList, FooterMod ft)
        {
            AdminPanel = admPanel;
            FooterList = ftrList;
            Footer = ft;
        }
    }
}