using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSale.Areas.AdminPart.Models.ModelView;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Controllers
{
    public class ProductController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        public ActionResult GetProduct()
        {
            ProductView productView = new ProductView();
            if (User.Identity.IsAuthenticated)
            {
                if (db != null)
                {
                    productView.AdminPanel = db.getAdminPanel();
                    productView.ProductsCategory = db.getProductsCategory();
                    productView.ProductCategory = new ProductCategory();
                    ViewBag.AdminTitle = "Məhsullar kategoriyası";
                    return View(productView);
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost]
        public ActionResult AddProduct(ProductView prdCategory)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (prdCategory.ProductCategory != null&&!(string.IsNullOrEmpty(prdCategory.ProductCategory.ProductName)))
                {
                    bool result = false;
                    if (prdCategory.ProductCategory.Id == 0)
                        result = db.insertProduct(prdCategory.ProductCategory);
                    else
                        result = db.updateProduct(prdCategory.ProductCategory);
                    if (result)
                        return RedirectToAction("GetProduct", "Product");
                    return HttpNotFound();

                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult UpdateProduct(int Id)
        {
            ProductView productView = new ProductView();
            if (User.Identity.IsAuthenticated)
            {
                if (Id != 0)
                {
                    ProductCategory prdCategory = db.getProdcut(Id) as ProductCategory;
                    if (prdCategory != null)
                    {
                        productView.AdminPanel = db.getAdminPanel();
                        productView.ProductCategory = prdCategory;
                        productView.ProductsCategory = db.getProductsCategory();
                        ViewBag.Text = "block";
                        return View("GetProduct", productView);

                    }
                }
                return View("GetProduct");
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult DeleteProduct(int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Id != 0)
                {
                    db.deleteProduct(Id);
                    return RedirectToAction("GetProduct");
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
    }
}