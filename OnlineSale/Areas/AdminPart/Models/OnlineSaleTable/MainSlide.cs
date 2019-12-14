using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class MainSlide
    {
        public int Id { get; set; }
        public string SlideName { get; set; }
        public string PhotoPath { get; set; }
        public int RowNumber { get; set; }
        public MainSlide() { }
        public MainSlide(string slideName, string photoPath, int rowNum)
        {
            SlideName = slideName;
            PhotoPath = photoPath;
            RowNumber = rowNum;
        }
    }
}