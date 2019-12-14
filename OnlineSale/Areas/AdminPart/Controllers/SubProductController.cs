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
    public class SubProductController : Controller
    {

        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        ProductSubCatView prodSubView = new ProductSubCatView();
        public ActionResult GetSubProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                prodSubView.AdminPanel = db.getAdminPanel();
                prodSubView.SubProductsCategory = db.getSubProducts();
                prodSubView.ProductsCategorys = db.getProductsCategory();
                prodSubView.MadeInId = db.getMadeIn();
                ViewBag.Category = new SelectList(prodSubView.ProductsCategorys, "Id", "ProductName");
                ViewBag.MadeInId = new SelectList(prodSubView.MadeInId, "Id", "Names");
                return View(prodSubView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost]
        public ActionResult AddSubPruduct(ProductSubCategory subPrdCategory)
        {
            if (User.Identity.IsAuthenticated)
            {
                bool result = false;
                if (subPrdCategory != null)
                {
                    if (subPrdCategory.Id == 0)
                        result = db.insertSubProduct(subPrdCategory);
                    else
                        result = db.updateSubProduct(subPrdCategory);
                    if (result)
                        return RedirectToAction("GetSubProduct");
                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult UpdateSubProduct(int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Id != 0)
                {
                    ProductSubCategory selectedSubProduct = db.getSubProduct(Id) as ProductSubCategory;
                    if (selectedSubProduct != null)
                    {
                        prodSubView.AdminPanel = db.getAdminPanel();
                        prodSubView.ProductSubCat = selectedSubProduct;
                        prodSubView.ProductsCategorys = db.getProductsCategory();
                        prodSubView.SubProductsCategory = db.getSubProducts();
                        prodSubView.MadeInId = db.getMadeIn();
                        ViewBag.Category = new SelectList(prodSubView.ProductsCategorys, "Id", "ProductName", selectedSubProduct.ProductCategoryId);
                        ViewBag.MadeInId = new SelectList(prodSubView.MadeInId, "Id", "Names",selectedSubProduct.MadeInId);
                        return View("GetSubProduct", prodSubView);
                    }
                    else
                        return HttpNotFound();

                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult DeleteSubProduct(int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                bool b = db.deleteSubProduct(Id);
                if (b)
                    return RedirectToAction("GetSubProduct");
                return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
    }
}