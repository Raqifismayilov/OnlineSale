using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class AdminListView : IAdminPanel
    {
        public AdminPanel LeftAdminPanel { get; set; }
        public List<AdminPanel> AdminPanel { get; set; }
        public AdminListView() { }
    }
}