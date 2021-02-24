using SalesTaxes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    public class ProductModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductTypeEnum productType { get; set; }
        public bool IsImported { get; set; }

        public ProductModel() { }
    }
}
