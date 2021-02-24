using SalesTaxes.Repository;
using SalesTaxes.Services;
using SalesTaxes.Utils;
using System;
using Xunit;

namespace SalesTaxesTest
{
    public class DecimalExtensionMethodTest
    {
        [Fact]
        public void Round()
        {
            //Arrange
            var decimals = new decimal[] { (decimal)2.63, (decimal)2.60, (decimal)2.66, (decimal)2.99 };

            //Act
            var result1 = decimals[0].Round();
            var result2 = decimals[1].Round();
            var result3 = decimals[2].Round();
            var result4 = decimals[3].Round();

            //Assert
            Assert.Equal((decimal)2.65, result1);
            Assert.Equal((decimal)2.60, result2);
            Assert.Equal((decimal)2.70, result3);
            Assert.Equal((decimal)3.00, result4);

        }
    }
}
