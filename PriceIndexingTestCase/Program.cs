using System;
using System.Collections.Generic;
using System.Linq;
namespace PriceIndexing
{
	public class PricePeek
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
	public class Program
    {
   
		public static List<PricePeek> FindLeastRightItemPrice(List<int> prices)
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
