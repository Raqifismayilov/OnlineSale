using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.UserSign;
using OnlineSale.Areas.AdminPart.Models.HashModel;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;

namespace OnlineSale.Areas.AdminPart.Controllers
{
    public class LogonController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        HashingPwd pwd = new HashingPwd();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserSignIn user)
        {
            try
            {
                UserSignIn usr = user as UserSignIn;
                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.Username, false);
                    return RedirectToAction("GetAdminPanel", "AdminPanel");
                    List<UserSignIn> usrPWdControl = db.UserLogin(usr);
                    if (usrPWdControl != null)
                    {
                        foreach (UserSignIn usrItem in usrPWdControl)
                            if (pwd.ValidatePassword(usr.Password, usrItem.HashSalt, usrItem.HashPasword))
                            {
                                FormsAuthentication.SetAuthCookie(usrItem.Username, false);
                                return RedirectToAction("GetAdminPanel", "AdminPanel");
                            }
                            else
                                return RedirectToAction("Login");
                    }
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet]
        public ActionResult RecoveryUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecoveryUser(string email)
        {
            if (!(string.IsNullOrEmpty(email)))
            {
                bool result = db.GetUserEmail(email);
                if (result)
                {
                    ViewBag.Result = "Məlumat elektron poctuvunuza göndərildi";
                    return View();
                }
                else
                {
                    ViewBag.Result = "Bu email barəsində heç bir məlumat yoxdur.";
                    return View();
                }
            }
            else
            {
                ViewBag.Result = "Xaiş olunur elektron poçtunuzu daxil edəsiniz";
            }
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

    }
}