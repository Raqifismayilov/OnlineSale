using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class StockView: IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public Stock Stock { get; set; }
        public SlideMod Slide { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public List<Stock> StockList { get; set; }
        public List<ProductCategory> PrdCategory { get; set; }
        public List<ProductSubCategory> prdSubCategorylist { get; set; }
        public List<SlideMod> SlideList { get; set; }
        public List<ProductDetail> productsDetails { get; set; }
        public List<SubColor> ColorList { get; set; }
        public List<SubValuta> ValutaList { get; set; }
        public List<SubEndrim> EndrimList { get; set; }
        public ProductDetail SubPrdDetail { get; set; }
        public int SubImageCount { get; set; }
        public StockView() { }
    }
}