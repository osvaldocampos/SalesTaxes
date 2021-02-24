using SalesTaxes.Enums;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using SalesTaxes.Utils;

namespace SalesTaxes.Services
{
    public class ReceiptService : IReceiptService
    {
        private ITaxExceptionRepository _taxExceptionRepository;        
        public ReceiptService(ITaxExceptionRepository taxExceptionRepository)
        {
            _taxExceptionRepository = taxExceptionRepository;
        }

        public ReceiptModel GenerateReceipt(List<ProductModel> products)
        {
            //TODO: Move taxes rates to the data source service
            var receiptItems = (from product in products
                    group product by product.Description into grp
                    select new ReceiptItemModel()
                    {
                        Description = grp.Key,
                        Price = grp.First().Price,
                        Qty = grp.Count(),
                        Taxes = new List<int>() 
                        { 
                            ImportedTax(grp.First().IsImported), 
                            BasicTax(grp.First().productType) 
                        }
                    }).ToList();

            receiptItems.ForEach(x => EvaluateItem(x));

            return new ReceiptModel()
            {
                TotalSalesTaxes = receiptItems.Select(x => x.SalesTaxes).Sum(),
                Total = receiptItems.Select(x => x.Total).Sum(),
                Items = receiptItems
            };
        }

        private int BasicTax(ProductTypeEnum productType)
        {
            var taxException = _taxExceptionRepository.GetByProductType(productType);

            if (taxException != null)
                return 0;

            return 10;
        }

        private int ImportedTax(bool isImported)
        {
            return isImported ? 5 : 0;
        }

        private void EvaluateItem(ReceiptItemModel receiptItem)
        {

            receiptItem.Taxes.ForEach(x => {
                receiptItem.SalesTaxes += ((receiptItem.Price * x) / 100).Round();
            });            

            receiptItem.Total = (receiptItem.Price + receiptItem.SalesTaxes) * receiptItem.Qty;
        }
    }
}
