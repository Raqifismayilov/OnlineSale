using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;


namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class UserView : IAdminPanel
    {
        public int Id { get; set; }
        public UserMod User { get; set; }
        public UserType UserType { get; set; }
        public List<AdminPanel> AdminPanel { get; set; }
        public List<UserMod> UserList { get; set; }
        public List<UserType> UserTypeList { get; set; }

        public UserView() { }
    }
}