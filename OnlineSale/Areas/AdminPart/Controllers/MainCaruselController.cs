using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.ModelView;

namespace OnlineSale.Areas.AdminPart.Controllers
{
    public class MainCaruselController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        MainSlideView slideMainView = new MainSlideView();
        public ActionResult GetMainSlide()
        {
            if (User.Identity.IsAuthenticated)
            {
                slideMainView.AdminPanel = db.getAdminPanel();
                slideMainView.MainSlideList = db.getMainSlide();
                slideMainView.ProductList = db.getProductsCategory();
                slideMainView.SubProductList = db.getSubProducts();
                slideMainView.StockList = db.getStockList();
                slideMainView.MainSlide = new MainSlide();
                return View(slideMainView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult AddMainSlide(MainSlide mainSlide, HttpPostedFileBase PhotoPath)
        {
            if (User.Identity.IsAuthenticated)
            {
                mainSlide.PhotoPath = PhotoPath.FileName;
                if (mainSlide != null)
                {
                    bool result = db.insertMainSlide(mainSlide);
                    if (result)
                    {
                        PhotoPath.SaveAs(Server.MapPath("/Content/MainSlideImg/" + mainSlide.PhotoPath));
                        return RedirectToAction("GetMainSlide");
                    }
                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
    }
}