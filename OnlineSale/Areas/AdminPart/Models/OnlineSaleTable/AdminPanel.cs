using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class AdminPanel
    {
        public int Id { get; set; }
        public string AdminCategory { get; set; }
        public string CategoryPath { get; set; }
        public string LogoPath { get; set; }
        public bool? AdminUsert { get; set; }
        public int RowsNum { get; set; }
        public AdminPanel() { }
        public AdminPanel(string adminCategory, string categoryPath, string lgPath, bool? admUsert, int rNum)
        {
            AdminCategory = adminCategory;
            CategoryPath = categoryPath;
            LogoPath = lgPath;
            AdminUsert = admUsert;
            RowsNum = rNum;
        }
    }
}