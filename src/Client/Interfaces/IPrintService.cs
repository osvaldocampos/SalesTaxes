using SalesTaxes.Models;

namespace SalesTaxes.Interfaces
{
    public interface IPrintService
    {
        void Print(ReceiptModel receipt);
    }
}