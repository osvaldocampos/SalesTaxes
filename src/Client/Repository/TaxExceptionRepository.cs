using SalesTaxes.Enums;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System;
using System.Linq;

namespace SalesTaxes.Repository
{
    public class TaxExceptionRepository : ITaxExceptionRepository
    {
        private IDataSourceService _dataSourceService;
        public TaxExceptionRepository(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public TaxExceptionModel GetByProductType(ProductTypeEnum productType)
        {
            return _dataSourceService.TaxExceptions.SingleOrDefault(x => x.ProductType == productType);
        }

    }
}
