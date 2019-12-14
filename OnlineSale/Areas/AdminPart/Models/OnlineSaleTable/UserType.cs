using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class UserType
    {
        public short Id { get; set; }
        public string TypeName { get; set; }
        public UserType() { }
        public UserType(string userType)
        {
            TypeName = userType;
        }
    }
}