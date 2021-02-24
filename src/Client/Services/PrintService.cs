using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System;

namespace SalesTaxes.Services
{
    public class PrintService : IPrintService
    {
        public PrintService()
        { }

        public void Print(ReceiptModel receipt)
        {
            foreach (var item in receipt.Items)
            {
                if (item.Qty > 1)
                    Console.WriteLine($"{ item.Description }: { item.Price * item.Qty } ({ item.Qty } @ { item.Price })");

                if (item.Qty == 1)
                    Console.WriteLine($"{ item.Description }: { item.Price }");
            }

            Console.WriteLine($"Sales Taxes: { receipt.TotalSalesTaxes }");
            Console.WriteLine($"Total: { receipt.Total }");
        }
    }
}
