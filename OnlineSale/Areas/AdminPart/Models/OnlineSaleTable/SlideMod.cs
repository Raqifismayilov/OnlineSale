using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class SlideMod
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string PhotoPath { get; set; }
        public int RowsNumber { get; set; }
        public int SubProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public SlideMod()
        {

        }
        public SlideMod(int stockId, string photoPath, int rowsNum, int subPrdId, string prdName, int prdId)
        {
            StockId = stockId;
            PhotoPath = photoPath;
            RowsNumber = rowsNum;
            SubProductId = subPrdId;
            ProductName = prdName;
            ProductId = prdId;
        }
    }
}