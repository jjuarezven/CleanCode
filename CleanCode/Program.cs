using CleanCode.Classes;
using CleanCode.Classes.Calculators;
using CleanCode.Classes.Factories;
using CleanCode.Interfaces;
using System;
using System.Collections.Generic;

namespace CleanCode
{
	class Program
	{
		static void Main(string[] args)
		{
			//var dc = new DiscountManager();
			//var dc = new DiscountManager(new DefaultAccountDiscountCalculatorFactory(), new DefaultLoyaltyDiscountCalculator());


			var discountsDictionary = new Dictionary<AccountStatus, IAccountDiscountCalculator>
			{
				{AccountStatus.NotRegistered, new NotRegisteredDiscountCalculator()},
				{AccountStatus.SimpleCustomer, new SimpleCustomerDiscountCalculator()},
				{AccountStatus.ValuableCustomer, new ValuableCustomerDiscountCalculator()},
				{AccountStatus.MostValuableCustomer, new MostValuableCustomerDiscountCalculator()}
			};

			var dc = new DiscountManager(new DictionarableAccountDiscountCalculatorFactory(discountsDictionary), new DefaultLoyaltyDiscountCalculator());


			Action<DiscountManager, AccountStatus> perform = PerformCalculation;

			AccountStatus status = AccountStatus.NotRegistered;
			perform(dc, status);

			status = AccountStatus.SimpleCustomer;
			perform(dc, status);

			status = AccountStatus.ValuableCustomer;
			perform(dc, status);

			status = AccountStatus.MostValuableCustomer;
			perform(dc, status);

			Console.ReadKey();
		}

		private static void PerformCalculation(DiscountManager dc, AccountStatus status)
		{
			decimal priceWithDiscount = 0;
			string message = string.Empty;
			priceWithDiscount = dc.ApplyDiscount(20000, status, 3);
			message = $"{status.GetAttributeDescription()},  20000, 3 years, {priceWithDiscount}";
			Console.WriteLine(message);
		}
	}
}
