using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Utils
{    
    public class ProductModelBuilder
    {
        private string _lineItem;

        private ProductModelBuilder() { }

        public static ProductModelBuilder Get() => new ProductModelBuilder();

        public ProductModelBuilder WithProperties(string lineItem)
        {
            _lineItem = lineItem;
            return this;
        }

        public Result<ProductModel> Build()
        {
            try
            {
                var values = _lineItem.ToLowerInvariant().Split(" at ");
                
                int descriptionIndex = values[0].IndexOf(' ');

                decimal price = decimal.Parse(values[1]);

                string description = values[0].Substring(descriptionIndex, values[0].Length - 1).Trim();

                return Result<ProductModel>.Ok(
                    new ProductModel()
                    {
                        Description = description,
                        Price = price
                    });
            }
            catch (Exception)
            {
                return Result<ProductModel>.Fail("Invalid arguments");
            }

        }
    }


}
