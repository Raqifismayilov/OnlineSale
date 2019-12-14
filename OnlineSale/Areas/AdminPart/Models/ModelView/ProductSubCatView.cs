using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using System.Web.Mvc;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class ProductSubCatView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public ProductSubCategory ProductSubCat { get; set; }
        public List<ProductSubCategory> SubProductsCategory { get; set; }
        public List<ProductCategory> ProductsCategorys { get; set; }
        public List<MadeIn> MadeInId { get; set; }
        public ProductSubCatView() { }

        public ProductSubCatView(ProductSubCategory prdSubCt, List<ProductSubCategory> subPrdsCts, List<ProductCategory> prdsCts)
        {
        }

        public ProductSubCatView(AdminPanel admnPanel, ProductSubCategory prdSubCt, List<ProductSubCategory> subPrdsCts, List<ProductCategory> prdsCts)
        {
        }
    }
}