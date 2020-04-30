using System;
using Xunit;
using PriceIndexing;
using System.Collections.Generic;
using System.Linq;
namespace PriceIndexingTestCase
{
    public class PriceIndexingTest
    {
        [Fact]
        public void FindLeastMimumNumberFor5()
        {

            int[] prices = { 5, 6, 1, 8, 3, 2 };
            List<PricePeek> peekPrices = Program.FindLeastRightItemPrice(prices.ToList<int>());
            PricePeek pricePeek = peekPrices.Find(p => p.Price == 5);
            Assert.Equal( 1, Convert.ToInt32(pricePeek.LeastMinimumPrice));
        }

        [Fact]
        public void FindLeastMimumNumberNullForNumber1()
        {

            int[] prices = { 5, 6, 1, 8, 3, 2 };
            List<PricePeek> peekPrices = Program.FindLeastRightItemPrice(prices.ToList<int>());
            //
            PricePeek pricePeek = peekPrices.Find(p => p.Price == 1);
            Assert.Null(pricePeek.LeastMinimumPrice);
        }


        [Fact]
        public void FindAccumulativeDiscount()
        {

            int[] prices = { 5, 6, 1, 8, 3, 2 };
            List<PricePeek> peekPrices = Program.FindLeastRightItemPrice(prices.ToList<int>());
            int total_discount = 0;
            foreach (PricePeek pricePeek in peekPrices)
            {
                if (pricePeek.LeastMinimumPrice != null)
                    total_discount += pricePeek.Price - Convert.ToInt32(pricePeek.LeastMinimumPrice);
                else
                    total_discount += pricePeek.Price;
            }

            Console.WriteLine(total_discount);

            List<PricePeek> nonDiscountedPrices = peekPrices.FindAll(p => p.LeastMinimumPrice == null);
            foreach (PricePeek pricePeek in nonDiscountedPrices)
            {
                Console.WriteLine(pricePeek.Price);
            }

            Assert.Equal(19, total_discount);

        }
    }
}
