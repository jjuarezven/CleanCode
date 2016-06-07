using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanCode
{
	class Program
	{
		static void Main(string[] args)
		{
			var dc = new DiscountManager();
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
