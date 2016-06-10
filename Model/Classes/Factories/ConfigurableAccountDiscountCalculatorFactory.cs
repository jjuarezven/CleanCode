using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Classes.Factories
{
	public class ConfigurableAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
	{
		private readonly Dictionary<AccountStatus, IAccountDiscountCalculator> _discountsDictionary;
		public ConfigurableAccountDiscountCalculatorFactory(Dictionary<AccountStatus, string> discountsDictionary)
		{
			_discountsDictionary = ConvertStringsDictToObjectsDict(discountsDictionary);
		}

		public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
		{
			IAccountDiscountCalculator calculator;

			if (!_discountsDictionary.TryGetValue(accountStatus, out calculator))
			{
				throw new NotImplementedException("There is no implementation of IAccountDiscountCalculatorFactory interface for given Account Status");
			}

			return calculator;
		}

		private Dictionary<AccountStatus, IAccountDiscountCalculator> ConvertStringsDictToObjectsDict(
			Dictionary<AccountStatus, string> dict)
		{
			return dict.ToDictionary(x => x.Key,
				x => (IAccountDiscountCalculator)Activator.CreateInstance(Type.GetType(x.Value)));
		}
	}
}
