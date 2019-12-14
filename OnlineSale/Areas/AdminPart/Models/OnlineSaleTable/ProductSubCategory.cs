using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string SubPrdName { get; set; }
        public int ProductCategoryId { get; set; }
        public short MadeInId { get; set; }
        public ProductSubCategory() { }
        public ProductSubCategory(string subPrdName, int prdCatId, short madeId)
        {
            SubPrdName = SubPrdName;
            ProductCategoryId = prdCatId;
            MadeInId = madeId;
        }
    }
}