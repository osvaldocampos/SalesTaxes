using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Interfaces
{
    public interface IDataSourceService
    {
        List<ProductModel> Products { get; set; }
        List<TaxExceptionModel> TaxExceptions { get; set; }
        
        void Seed();
    }
}
