using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class MadeIn
    {
        public short Id { get; set; }
        public string Names { get; set; }
        public MadeIn() { }
        public MadeIn(string name)
        {
            Names = name;
        }
    }
}