using SalesTaxes.Models;

namespace SalesTaxes.Interfaces
{
    public interface IProductRepository
    {
        ProductModel GetByName(string name);
    }
}