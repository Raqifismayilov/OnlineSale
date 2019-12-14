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
    public class ContactController : Controller
    {
        OnlineSaleDB db = new OnlineSaleDB("OnlineSale");
        ContactView contactView = new ContactView();
        public ActionResult GetContact()
        {
            if (User.Identity.IsAuthenticated)
            {
                contactView.AdminPanel = db.getAdminPanel();
                contactView.ContactList = db.getContactList();
                contactView.Contacts = new ContactMod();
                return View(contactView);
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpPost]
        public ActionResult AddContact(ContactMod contact)
        {
            if (User.Identity.IsAuthenticated)
            {

                if (contact != null)
                {
                    bool result = db.insertContact(contact);
                    if (result)
                        return RedirectToAction("GetContact");
                    return HttpNotFound();
                }
                else
                    return HttpNotFound();
            }
            else
                return RedirectToAction("Login", "Logon");
        }
        [HttpGet]
        public ActionResult UpdateContact(short id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != 0)
                {
                    ContactMod contact = db.getContact(id) as ContactMod;
                    if (contact != null)
                    {
                        contactView.AdminPanel = db.getAdminPanel();
                        contactView.ContactList = db.getContactList();
                        contactView.Contacts = contact;
                        return View("GetContact", contactView);
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
        [HttpGet]
        public ActionResult DeleteContact(short id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != 0)
                {
                    bool result = db.deleteContact(id);
                    if (result)
                        return RedirectToAction("GetContact");
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