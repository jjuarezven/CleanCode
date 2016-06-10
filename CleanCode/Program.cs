using DataBaseConfiguration;
using Model;
using Model.Classes;
using Model.Classes.Calculators;
using Model.Classes.Factories;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CleanCode
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = Directory.GetCurrentDirectory();
			path = Path.GetFullPath(Path.Combine(path, @"..\..\") + "App_Data");
			AppDomain.CurrentDomain.SetData("DataDirectory", path);
			using (var ctx = new CleanCodeContext())
			{
				DiscountCalculatorConfigurationItem stud = new DiscountCalculatorConfigurationItem() { AccountStatus = AccountStatus.MostValuableCustomer, Implementation = "Model.Classes.Calculators.MostValuableCustomer, Model" };

				ctx.DiscountCalculatorConfigurationItems.Add(stud);

				ctx.SaveChanges();
				var x = ctx.DiscountCalculatorConfigurationItems.ToList();
			}

			//var dc = new DiscountManager();
			//var dc = new DiscountManager(new DefaultAccountDiscountCalculatorFactory(), new DefaultLoyaltyDiscountCalculator());


			#region configuracion para factory con diccionario
			//var discountsDictionary = new Dictionary<AccountStatus, IAccountDiscountCalculator>
			//{
			//	{AccountStatus.NotRegistered, new NotRegisteredDiscountCalculator()},
			//	{AccountStatus.SimpleCustomer, new SimpleCustomerDiscountCalculator()},
			//	{AccountStatus.ValuableCustomer, new ValuableCustomerDiscountCalculator()},
			//	{AccountStatus.MostValuableCustomer, new MostValuableCustomerDiscountCalculator()}
			//};

			//var dc = new DiscountManager(new DictionarableAccountDiscountCalculatorFactory(discountsDictionary), new DefaultLoyaltyDiscountCalculator());
			#endregion

			/*
			 We are using a constructor of the Lazy class which takes a Func delegate as a parameter. When we will try to access the Value property of stored in our dictionary value (Lazy type) 
			 for the first time, this delegate will be executed and a concrete calculator implementation will be created.
			 Now the concrete calculator implementation will be created after the first request for it will be executed. Each next call for the same implementation will return 
			 the same (created while the first call) object.
			 */


			var lazyDiscountsDictionary = new Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>>
			{
				{AccountStatus.NotRegistered, new Lazy<IAccountDiscountCalculator>(() => new NotRegisteredDiscountCalculator()) },
				{AccountStatus.SimpleCustomer, new Lazy<IAccountDiscountCalculator>(() => new SimpleCustomerDiscountCalculator())},
				{AccountStatus.ValuableCustomer, new Lazy<IAccountDiscountCalculator>(() => new ValuableCustomerDiscountCalculator())},
				{AccountStatus.MostValuableCustomer, new Lazy<IAccountDiscountCalculator>(() => new MostValuableCustomerDiscountCalculator())}
			};
			var dc = new DiscountManager(new DictionarableLazyAccountDiscountCalculatorFactory(lazyDiscountsDictionary), new DefaultLoyaltyDiscountCalculator());


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
