using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSale.Areas.AdminPart.Models.OnlineSaleTable;

namespace OnlineSale.Models
{
    public class TopProductSlide
    {
        public int Id { get; set; }
        public List<StockUser> StockListNew { get; set; }
        public List<StockUser> StockListEndirim { get; set; }
        public List<StockUser> StockListMixed { get; set; }
        public TopProductSlide() { }
        public TopProductSlide(List<StockUser> stkListNew, List<StockUser> stkListEnd, List<StockUser> stkListMix)
        {
            StockListNew = stkListNew;
            StockListEndirim = stkListEnd;
            StockListMixed = stkListMix;
        }

    }
}