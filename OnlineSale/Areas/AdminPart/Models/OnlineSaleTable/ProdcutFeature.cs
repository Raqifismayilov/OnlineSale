using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class ProdcutFeature
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ProdcutFeature() { }
    }
}