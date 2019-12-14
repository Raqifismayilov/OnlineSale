using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class SearchInCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubProductId { get; set; }
        public bool? ProductCondition { get; set; }
        public string ProductName { get; set; }
        public SearchInCategory() { }
        public SearchInCategory(int prdId, int sbPrdId, bool? prdCond, string prdName)
        {
            ProductId = prdId;
            SubProductId = sbPrdId;
            ProductCondition = prdCond;
            ProductName = prdName;
        }
    }
}