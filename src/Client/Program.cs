using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using SalesTaxes.DependencyResolution;
using SalesTaxes.Utils;

namespace SalesTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = ServicesRegistry
                .Register(serviceCollection)
                .BuildServiceProvider();

            var dataSource = serviceProvider.GetService<IDataSourceService>();
            dataSource.Seed();

            var productRepository = serviceProvider.GetService<IProductRepository>();
            var receiptService = serviceProvider.GetService<IReceiptService>();
            var printerService = serviceProvider.GetService<IPrintService>();

            List<ProductModel> products = new List<ProductModel>();

            bool requestTotal = false;
            while (!requestTotal)
            {
                Console.WriteLine("Enter the product eg.(1 Book at 12.49):");
                string productDescription = Console.ReadLine();

                var result = ProductModelBuilder
                    .Get()
                    .WithProperties(productDescription)
                    .Build();

                if (!result.IsSuccess)
                {
                    Console.WriteLine($"There was an error trying to build the product: { result.Message }");
                    continue;
                }

                ProductModel product = productRepository.GetByName(result.Value.Description);
                product.Price = result.Value.Price;

                if (product == null)
                {
                    Console.WriteLine("Product not found");
                    continue;
                }

                products.Add(product);


                Console.WriteLine("Press (Esc) to finish or <Enter> to add an other product.");
                bool waitingForUser = true;
                while(waitingForUser)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        waitingForUser = false;
                        requestTotal = true;
                        continue;
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        waitingForUser = false;
                        continue;
                    }
                }

            }

            var receipt = receiptService.GenerateReceipt(products);
            printerService.Print(receipt);

        }
    }
}
