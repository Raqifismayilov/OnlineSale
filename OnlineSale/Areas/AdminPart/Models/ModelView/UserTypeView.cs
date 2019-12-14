using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class UserTypeView : IAdminPanel
    {
        public UserType userType { get; set; }
        public List<AdminPanel> AdminPanel { get; set; }
        public List<UserType> usersTypes { get; set; }
        public UserTypeView() { }
    }
}
