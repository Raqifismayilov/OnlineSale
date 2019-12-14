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
    public class UsersTypesController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        UserTypeView userType = new UserTypeView();
        public ActionResult UserStatus()
        {
            if (User.Identity.IsAuthenticated)
            {
                userType.AdminPanel = db.getAdminPanel();
                userType.usersTypes = db.getUserTypes();
                return View(userType);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpGet]
        public ActionResult AddUserTypes()
        {
            if (User.Identity.IsAuthenticated)
            {
                userType.AdminPanel = db.getAdminPanel();
                userType.userType = new UserType();
                return View(userType);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost]
        public ActionResult AddUserTypes(UserType userType)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (userType != null)
                {
                    db.InsertUserType(userType);
                    return RedirectToAction("UserStatus");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult UpdateUserType(short Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Id != 0)
                {
                    userType.AdminPanel = db.getAdminPanel();
                    userType.userType = db.GetUserType(Id);
                    return View("AddUserTypes", userType);
                }
                else
                    return new HttpNotFoundResult();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult DeleteUserType(short Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Id != 0)
                {
                    if (db.deleteUserType(Id))
                    {
                        return RedirectToAction("UserStatus");
                    }
                    else
                    {
                        return new HttpNotFoundResult();
                    }
                }
                else
                    return new HttpNotFoundResult();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
    }
}