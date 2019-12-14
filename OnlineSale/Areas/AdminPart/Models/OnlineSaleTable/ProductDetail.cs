using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubCategory { get; set; }
        public string Name { get; set; }
        public string Values { get; set; }
        public ProductDetail() { }
        public ProductDetail(int stockId)
        {
            StockId = stockId;
        }
    }
}