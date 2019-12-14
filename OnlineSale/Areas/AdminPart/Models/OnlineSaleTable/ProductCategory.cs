﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.OnlineSaleTable
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public ProductCategory() { }
        public ProductCategory(string productCategory)
        {
            ProductName = productCategory;
        }
    }
}