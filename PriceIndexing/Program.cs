using System;
using System.Collections.Generic;
using System.Linq;
namespace PriceIndexing
{
	class PricePeek
	{
		public int Price
		{
			get;
			set;
		}

		public int? LeastMinimumPrice
		{
			get;
			set;
		}

		public int Index
		{
			get;
			set;
		}

	}
	class Program
    {
        static void Main(string[] args)
        {
			int[] prices = { 5, 6, 1, 8, 3, 2 };
			List<PricePeek> peekPrices = FindLeastRightItemPrice(prices.ToList<int>());
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


			Console.ReadLine();
		}
		static List<PricePeek> FindLeastRightItemPrice(List<int> prices)
		{
			int startIndex = 1;
			int difference = 0;
			List<int> _minimumPrices = new List<int>();
			List<PricePeek> _pricePeeks = new List<PricePeek>();
			PricePeek _pricePeek = null;
			foreach (var price in prices)
			{
				_minimumPrices = new List<int>();

				for (int i = startIndex; i < prices.Count; i++)
				{
					difference = price - prices[i];
					if (difference >= 0)
					{
						_minimumPrices.Add(prices[i]);
					}
				}
				if (_minimumPrices.Count > 0)
				{
					_pricePeek = new PricePeek();
					_minimumPrices = _minimumPrices.OrderBy(p => p).ToList();
					_pricePeek.Index = startIndex;
					_pricePeek.LeastMinimumPrice = _minimumPrices[0];
					_pricePeek.Price = price;
					_pricePeeks.Add(_pricePeek);
				}
				else
				{
					_pricePeek = new PricePeek();
					_pricePeek.Index = startIndex;
					_pricePeek.LeastMinimumPrice = null;
					_pricePeek.Price = price;
					_pricePeeks.Add(_pricePeek);

				}


				startIndex++;
			}

			return _pricePeeks;

		}

	}
}
