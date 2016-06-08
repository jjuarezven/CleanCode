using CleanCode.Interfaces;

namespace CleanCode.Classes
{
	public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
		}
	}
}