using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;


namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class ProductView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductCategory> ProductsCategory { get; set; }
        public ProductView() { }
    }
}