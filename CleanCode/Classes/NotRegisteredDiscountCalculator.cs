using CleanCode.Interfaces;

namespace CleanCode.Classes
{
	public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price;
		}
	}
}