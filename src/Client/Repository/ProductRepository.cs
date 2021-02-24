using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System;
using System.Linq;

namespace SalesTaxes.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IDataSourceService _dataSourceService;
        public ProductRepository(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public ProductModel GetByName(string name)
        {
            return _dataSourceService.Products.SingleOrDefault(x => string.Equals(x.Description, name, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
