using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;
using OnlineSale.Areas.AdminPart.Models.ModelView;

namespace OnlineSale.Areas.AdminPart.Controllers
{
    public class FooterController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        FooterView footerView = new FooterView();
        public ActionResult GetFooter()
        {
            if (User.Identity.IsAuthenticated)
            {
                footerView.AdminPanel = db.getAdminPanel();
            footerView.FooterList = db.getFooters();
            return View(footerView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult AddFooter()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
    }
}