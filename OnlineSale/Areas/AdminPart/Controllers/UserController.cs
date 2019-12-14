using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSale.Areas.AdminPart.Models.ModelView;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleData;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;
using OnlineSale.Areas.AdminPart.Models.UserSign;
using OnlineSale.Areas.AdminPart.Models.HashModel;
using System.Text;

namespace OnlineSale.Areas.AdminPart.Controllers
{
    public class UserController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        UserView userView = new UserView();
        HashingPwd generetePwd = new HashingPwd();
        public ActionResult GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                userView.AdminPanel = db.getAdminPanel();
                userView.UserList = db.getUsers();
                userView.UserTypeList = db.getUserTypes();
                return View(userView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                userView.AdminPanel = db.getAdminPanel();
                userView.UserTypeList = db.getUserTypes();
                userView.User = new UserMod();
                return View(userView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost]
        public ActionResult AddUser(UserMod user)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    if (user != null && !(db.findUser(user.Username.Trim())))
                    {
                        byte[] salt;
                        byte[] pwd;
                        bool result = false;
                        generetePwd.SaltAndHashPassword(user.Password.Trim(), out salt, out pwd);
                        UserMod newUser = new UserMod(user.Firstname, user.Lastname, user.Username, user.Email, user.UserTypeId)
                        {
                            Id = user.Id,
                            SaltHash = salt,
                            PasswordHash = pwd
                        };
                        if (user.Id == 0)
                            result = db.insertUser(newUser);
                        else
                            result = db.updateUser(newUser);
                        return RedirectToAction("GetUser");
                    }
                    else
                        return Content("Pojalusta povtorite dobavlenie");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
            }
        }
            else
                return RedirectToAction("Login", "Logon");
    }
        public ActionResult UpdateUser(string param)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!(string.IsNullOrEmpty(param.Trim())))
                {
                    if (db.GetFirstUser(param) is UserMod newUser)
                    {
                        userView.AdminPanel = db.getAdminPanel();
                        userView.UserTypeList = db.getUserTypes();
                        userView.User = newUser;
                        return View("AddUser", userView);
                    }
                    else
                        return new HttpNotFoundResult();
                }
                else
                    return RedirectToAction("GetUser");
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        public ActionResult DeleteUser(string param)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!(string.IsNullOrEmpty(param.Trim())))
                {
                    if (db.deleteUser(param))
                        return RedirectToAction("GetUser");
                    else
                        return new HttpNotFoundResult();
                }
                else
                    return new HttpNotFoundResult();
            }
            else
                return RedirectToAction("GetUser");
        }
    }
}