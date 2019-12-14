using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class MainSlideView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public List<MainSlide> MainSlideList { get; set; }
        public List<ProductCategory> ProductList { get; set; }
        public List<ProductSubCategory> SubProductList { get; set; }
        public List<Stock> StockList { get; set; }
        public MainSlide MainSlide { get; set; }
        public MainSlideView() { }
        public MainSlideView(List<AdminPanel> adPanel, List<MainSlide> mSlideList, List<Stock> stockList, MainSlide mainSl)
        {
            AdminPanel = adPanel;
            MainSlideList = mSlideList;
            StockList = stockList;
            MainSlide = mainSl;
        }
    }
}