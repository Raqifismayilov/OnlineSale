using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;
using OnlineSale.Areas.AdminPart.Models.ModelView;
using OnlineSale.Models;

namespace OnlineSale.Controllers
{
    public class HomeController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        HomeView homeView = new HomeView();
        RandomProduct ranProduct = new RandomProduct();
        TopProductSlide topProduct = null;
        public ActionResult Index()
        {
            ViewBag.Title = "Allin.az:Elektronika və məişət texnika internet mağazası";
            homeView.AdminPanel = db.getAdminPanel();
            homeView.SubProductsCategory = db.getSubProducts();
            homeView.ProductsCategorys = db.getProductsCategory();
            topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
            homeView.TopSlidePruduct = topProduct;
            homeView.FooterList = db.getFooters();
            homeView.SocialMediaList = db.getSocialMedia();
            homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
            homeView.MainSlideList = db.getMainSlide();
            homeView.StockList = db.weekDiscount();
            ViewBag.Category = new SelectList(homeView.ProductsCategorys, "Id", "ProductName");
            return View(homeView);
        }
        [HttpGet]
        public ActionResult GetAbout()
        {
            ViewBag.Title = "Haqqımızda";
            homeView.AdminPanel = db.getAdminPanel();
            homeView.AboutList = db.getAboutList();
            homeView.SubProductsCategory = db.getSubProducts();
            homeView.ProductsCategorys = db.getProductsCategory();
            topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
            homeView.TopSlidePruduct = topProduct;
            homeView.FooterList = db.getFooters();
            homeView.SocialMediaList = db.getSocialMedia();
            homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
            return View(homeView);
        }
        public ActionResult GetContact()
        {
            ViewBag.Title = "Əlaqə";
            homeView.ContactList = db.getContactList();
            homeView.AdminPanel = db.getAdminPanel();
            homeView.SubProductsCategory = db.getSubProducts();
            homeView.ProductsCategorys = db.getProductsCategory();
            topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
            homeView.TopSlidePruduct = topProduct;
            // homeView.StockList = db.getStockStrList();
            homeView.FooterList = db.getFooters();
            homeView.SocialMediaList = db.getSocialMedia();
            homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
            return View(homeView);
        }
        public ActionResult GetLocation()
        {
            ViewBag.Title = "Xəritə";
            homeView.ContactList = db.getContactList();
            homeView.AdminPanel = db.getAdminPanel();
            homeView.SubProductsCategory = db.getSubProducts();
            homeView.ProductsCategorys = db.getProductsCategory();
            topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
            homeView.TopSlidePruduct = topProduct;
            homeView.FooterList = db.getFooters();
            homeView.SocialMediaList = db.getSocialMedia();
            homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
            return View(homeView);
        }
        [HttpGet]
        public ActionResult GetProduct(int id)
        {
            ViewBag.Title = "Məhsullar";
            homeView.AdminPanel = db.getAdminPanel();//Navbar menu
            homeView.SubProductsCategory = db.getSubProducts();//Menu Categoriya
            homeView.ProductsCategorys = db.getProductsCategory();//Menu Sub categoriya
            topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
            homeView.TopSlidePruduct = topProduct;
            homeView.StockList = db.getStockWherePrd(id);
            homeView.FooterList = db.getFooters();
            homeView.SocialMediaList = db.getSocialMedia();
            homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
            return View(homeView);
        }
        public ActionResult GetProductDetail(int id)
        {
            if (id != 0)
            {
                SubImgAndDet subImgAndDet = new SubImgAndDet(new List<SlideMod>(db.getSlideList(id)), new List<ProductDetail>(db.getProductDetail(id)));
                if (subImgAndDet.SubDetail.Count != 0&&subImgAndDet.SubSlide.Count!=0)
                {
                    homeView.AdminPanel = db.getAdminPanel();
                    homeView.SubProductsCategory = db.getSubProducts();
                    homeView.ProductsCategorys = db.getProductsCategory();
                    topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
                    homeView.TopSlidePruduct = topProduct;
                    homeView.FooterList = db.getFooters();
                    homeView.SubImageAndDetail = subImgAndDet;
                    homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
                    homeView.SocialMediaList = db.getSocialMedia();
                    Stock st = db.getStock(id);
                    ViewBag.ProductName = st.ProductName;
                    ViewBag.ProductCode = st.ProductCode;
                    ViewBag.Price = st.Price;
                    return View(homeView);
                }
                else
                    return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult SearchProduct(SearchInCategory srcPrd)
        {
            ViewBag.Title = "Axtarış";
            List<StockUser> stkFind = db.searchProduct(srcPrd);
            homeView.AdminPanel = db.getAdminPanel();//Navbar menu
            homeView.SubProductsCategory = db.getSubProducts();//Menu Categoriya
            homeView.ProductsCategorys = db.getProductsCategory();//Menu Sub categoriya
            topProduct = new TopProductSlide(db.getStockStrNewTop(), db.getStockStrEndirimTop(), ranProduct.getNewStockList(db.getStockStrList()));
            homeView.TopSlidePruduct = topProduct;
            homeView.StockList = stkFind;
            homeView.FooterList = db.getFooters();
            homeView.SocialMediaList = db.getSocialMedia();
            homeView.FeedbackEmail = db.getContactList().FirstOrDefault().Email;
            if (stkFind != null && stkFind.Count != 0)
            {
                return View(homeView);
            }
            else
            {
                ViewBag.Result = "Sorğu üzrə “" + srcPrd.ProductName + "” heç nә tapılmadı";
                ViewBag.SubResult = "Sorğunu dәyişdirmәk üçün cәhd edin vә ya mәhsul kataloqundan istifadә edin";
                return View(homeView);
            }
        }
        public ActionResult Question(Question question)
        {
            return RedirectToAction("GetAbout");
        }

    }
}