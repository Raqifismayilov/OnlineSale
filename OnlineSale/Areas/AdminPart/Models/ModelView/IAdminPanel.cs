using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSale.Areas.AdminPart.Models.ModelView;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    interface IAdminPanel
    {
        List<AdminPanel> AdminPanel { get; set; }
    }
}
