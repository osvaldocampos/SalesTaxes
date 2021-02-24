using SalesTaxes.Models;
using System.Collections.Generic;

namespace SalesTaxes.Interfaces
{
    public interface IReceiptService
    {
        ReceiptModel GenerateReceipt(List<ProductModel> products);
    }
}