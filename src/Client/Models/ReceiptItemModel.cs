using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    public class ReceiptItemModel
    {
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public List<int> Taxes { get; set; }
        public decimal SalesTaxes { get; set; }
        public decimal Total { get; set; }
        public ReceiptItemModel()
        { 
        }
    }
}
