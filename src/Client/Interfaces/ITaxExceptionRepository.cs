using SalesTaxes.Enums;
using SalesTaxes.Models;

namespace SalesTaxes.Interfaces
{
    public interface ITaxExceptionRepository
    {
        TaxExceptionModel GetByProductType(ProductTypeEnum productType);
    }
}