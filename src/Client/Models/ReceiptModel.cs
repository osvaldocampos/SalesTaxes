using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    public class ReceiptModel
    { 
        public List<ReceiptItemModel> Items { get; set; }
        public decimal TotalSalesTaxes { get; set; }
        public decimal Total { get; set; }
        public ReceiptModel()
        { 
        }
    }
}
