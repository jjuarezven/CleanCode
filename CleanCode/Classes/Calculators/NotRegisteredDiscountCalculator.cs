using CleanCode.Interfaces;

namespace CleanCode.Classes.Calculators
{
	public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price;
		}
	}
}