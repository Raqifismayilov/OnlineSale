using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class RandomProduct
    {
        List<StockUser> newList = new List<StockUser>();
        Random r = new Random();
        public RandomProduct() { }
        public List<StockUser> getNewStockList(List<StockUser> stockList)
        {
            int count = stockList.Count;
            for (int i = 0; i <= count; i++)
            {
                StockUser p = stockList[r.Next(count)] as StockUser;
                StockUser k = newList.Where(m => m.Id == p.Id).FirstOrDefault();
                if (p != k)
                {
                    newList.Add(p);
                    if (newList.Count == stockList.Count)
                        break;
                }
            }
            return newList;
        }
    }
}