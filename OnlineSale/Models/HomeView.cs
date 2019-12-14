using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.ModelView;

namespace OnlineSale.Models
{
    public class HomeView : ProductSubCatView, IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public ProductSubCategory ProductSubCat { get; set; }
        public List<ProductSubCategory> SubProductsCategory { get; set; }
        public List<ProductCategory> ProductsCategorys { get; set; }
        public List<FooterMod> FooterList { get; set; }
        public List<MainSlide> MainSlideList { get; set; }
        public List<AboutMod> AboutList { get; set; }
        public Question UserQuestion { get; set; }
        public TopProductSlide TopSlidePruduct { get; set; }
        public List<StockUser> StockListEndirimTop { get; set; }
        public List<StockUser> StockList { get; set; }
        public List<ContactMod> ContactList { get; set; }
        public List<SocialMediaMod> SocialMediaList { get; set; }
        public SubImgAndDet SubImageAndDetail { get; set; }
        public SearchInCategory SearchInCat { get; set; }

        public string FeedbackEmail { get; set; }
        public ProductCategory ProductFirstCat { get; set; }
        public HomeView() { }
        public HomeView(AdminPanel admnPanel, ProductSubCategory prdSubCt, List<ProductSubCategory> subPrdsCts, List<ProductCategory> prdsCts, List<FooterMod> footLst, List<StockUser> stcList) :
            base(admnPanel, prdSubCt, subPrdsCts, prdsCts)
        {
            ProductSubCat = prdSubCt;
            SubProductsCategory = subPrdsCts;
            ProductsCategorys = prdsCts;
            FooterList = footLst;
            StockList = stcList;            
        }
    }
}