using Newtonsoft.Json;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Services
{
    public class DataSourceService : IDataSourceService
    {
        public List<ProductModel> Products { get; set; }
        public List<TaxExceptionModel> TaxExceptions { get; set; }

        public DataSourceService()
        {
            Products = new List<ProductModel>();
        }

        public void Seed()
        {
            var productJson = System.IO.File.ReadAllText(@"Seed//ProductsSeed.json");
            var taxExceptionJson = System.IO.File.ReadAllText(@"Seed//TaxExceptionSeed.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { }; 

            Products =
               JsonConvert.DeserializeObject<List<ProductModel>>(productJson, settings);

            TaxExceptions =
                JsonConvert.DeserializeObject<List<TaxExceptionModel>>(taxExceptionJson, settings);
        }
    }
}
