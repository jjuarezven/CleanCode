using CleanCode.Interfaces;

namespace CleanCode.Classes
{
	public class SimpleCustomerDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price - (Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price);
		}
	}
}