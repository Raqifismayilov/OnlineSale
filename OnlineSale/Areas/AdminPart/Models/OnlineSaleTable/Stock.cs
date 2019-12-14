using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public int SubColorId { get; set; }
        public string MainPhotoPath { get; set; }
        public double Price { get; set; }
        public int SubValutaId { get; set; }
        public int Quantity { get; set; }
        public double Endirim { get; set; }
        public int? SubEndirimId { get; set; }
        public int RowsNumber { get; set; }
        public bool? ProductCondition { get; set; }
        public string ProductCode { get; set; }
        public Stock() { }
    }
}