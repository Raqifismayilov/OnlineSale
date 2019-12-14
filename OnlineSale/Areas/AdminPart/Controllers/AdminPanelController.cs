using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.ModelView;
using System.IO;


namespace OnlineSale.Areas.AdminPart.Controllers
{
    public class AdminPanelController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        AdminListView adminView = new AdminListView();
        public ActionResult GetAdminPanel()
        {
            if (User.Identity.IsAuthenticated)
            {
                adminView.AdminPanel = db.getAdminPanel();
                adminView.LeftAdminPanel = new AdminPanel();
                return View(adminView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost]
        public ActionResult AddCategory(AdminPanel adminPanel, HttpPostedFileBase LogoPath)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (adminPanel != null)
                {
                    bool result;
                    if (adminPanel.Id == 0)
                    {
                        adminPanel.LogoPath = LogoPath.FileName;
                        result = db.insertAdminPanel(adminPanel);
                    }
                    else
                        result = db.updateAdminPanel(adminPanel);
                    if (result)
                    {
                        LogoPath.SaveAs(Server.MapPath("~/Content/LogoImage/" + LogoPath.FileName));
                        return RedirectToAction("GetAdminPanel");
                    }
                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != 0)
                {
                    AdminPanel admPanel = db.getAdminPanel(id);
                    if (admPanel != null)
                    {
                        adminView.AdminPanel = db.getAdminPanel();
                        adminView.LeftAdminPanel = admPanel;
                        return View("GetAdminPanel", adminView);
                    }
                    else
                        return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else return RedirectToAction("Login", "Logon");

        }
        public ActionResult DeleteCategory(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != 0)
                {
                    AdminPanel admPanel = db.getAdminPanel(id) as AdminPanel;
                    string imgPath;
                    if (admPanel != null)
                    {
                        imgPath = admPanel.LogoPath;
                        bool result = db.deleteAdminPanel(id);
                        if (result)
                        {
                            System.IO.File.Delete(Server.MapPath("~/Content/LogoImage/" + imgPath));
                            return RedirectToAction("GetAdminPanel");
                        }
                        return HttpNotFound();
                    }
                    else return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
    }
}