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
    public class AboutController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        AboutView aboutView = new AboutView();
        [HttpGet]
        public ActionResult GetAbout()
        {
            if (User.Identity.IsAuthenticated)
            {
                aboutView.AdminPanel = db.getAdminPanel();
                aboutView.AboutList = db.getAboutList();
                aboutView.About = new AboutMod();
                return View(aboutView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAbout(AboutMod about)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (about != null)
                {
                    bool result;
                    if (about.Id == 0)
                        result = db.insertAbout(about);
                    else
                        result = db.updateAbout(about);
                    if (result)
                        return RedirectToAction("GetAbout");
                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != 0)
                {
                    AboutMod about = db.GetAbout(id) as AboutMod;
                    if (about != null)
                    {
                        aboutView.AdminPanel = db.getAdminPanel();
                        aboutView.AboutList = db.getAboutList();
                        aboutView.About = about;
                        return View("GetAbout", aboutView);
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
        public ActionResult DeleteAbout(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != 0)
                {
                    bool result = db.deleteAbout(id);
                    if (result)
                        return RedirectToAction("GetAbout");
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