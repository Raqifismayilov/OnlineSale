using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class SlideView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public List<Stock> StockList { get; set; }
        public List<SlideMod> SlideList { get; set; }
        public List<ProductCategory> ProductList { get; set; }
        public List<ProductSubCategory> ProductSubList { get; set; }
        public List<SubColor> ColorList { get; set; }
        public List<SubValuta> ValutaList { get; set; }
        public List<SubEndrim> EndrimList { get; set; }
        public SlideMod Slide { get; set; }
        public SlideView() { }
    }
}