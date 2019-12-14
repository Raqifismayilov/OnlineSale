using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Areas.AdminPart.Models.ModelView
{
    public class ContactView : IAdminPanel
    {
        public List<AdminPanel> AdminPanel { get; set; }
        public List<ContactMod> ContactList { get; set; }
        public ContactMod Contacts { get; set; }
        public ContactView() { }
        public ContactView(List<AdminPanel> adPanel, List<ContactMod> conList, ContactMod contact)
        {
            AdminPanel = adPanel;
            ContactList = conList;
            Contacts = contact;
        }
    }
}