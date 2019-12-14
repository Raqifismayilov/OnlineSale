using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class SubImgAndDet
    {
        public int Id { get; set; }
        public List<SlideMod> SubSlide { get; set; }
        public List<ProductDetail> SubDetail { get; set; }
        public SubImgAndDet() { }
        public SubImgAndDet(List<SlideMod> subSlid, List<ProductDetail> subDet)
        {
            SubSlide = subSlid;
            SubDetail = subDet;
        }
    }
}