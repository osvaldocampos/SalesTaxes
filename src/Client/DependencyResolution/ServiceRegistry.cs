using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Interfaces;
using SalesTaxes.Repository;
using SalesTaxes.Services;

namespace SalesTaxes.DependencyResolution
{
    public static class ServicesRegistry
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            return services
                .AddScoped<IDataSourceService, DataSourceService>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IReceiptService, ReceiptService>()
                .AddScoped<ITaxExceptionRepository, TaxExceptionRepository>()
                .AddScoped<IPrintService, PrintService>();
        }
    }
}
