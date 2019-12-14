using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class StockUser
    {
        public int Id { get; set; }
        public string ProductCategory { get; set; }
        public string SubPrdName { get; set; }
        public string ProductName { get; set; }
        public string ColorsCode { get; set; }
        public string MainPhotoPath { get; set; }
        public double Price { get; set; }
        public string ValutaType { get; set; }
        public int Quantity { get; set; }
        public double Endirim { get; set; }
        public string EndirimType { get; set; }
        public int RowsNumber { get; set; }
        public bool? ProductCondition { get; set; }
        public string ProductCode { get; set; }
        public StockUser() { }
        public double oldPrice()
        {
            double result;
            if (EndirimType == "%" && EndirimType != null)
            {
                double prdPersent = (Price * Endirim) / 100;
                result = Price - prdPersent;
            }
            else if (EndirimType != null)
                result = Price - Endirim;
            else
                result = 0;
            return result;
        }
        public void randomStockList(ref List<StockUser> randomStList)
        {
            int count;
            Random rand = new Random();
            if ((count = randomStList.Count) != 0)
            {
                int num = rand.Next(count);
                List<StockUser> stockNewList = new List<StockUser>(count);
                for (int i = count; i >= 0; i--)
                {
                    if (i >= 3)
                        stockNewList.Add(randomStList.ElementAt(i - 3));
                    else break;
                }

            }
        }

    }
}