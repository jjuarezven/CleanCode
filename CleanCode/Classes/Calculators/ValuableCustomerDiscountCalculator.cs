using CleanCode.Interfaces;

namespace CleanCode.Classes.Calculators
{
	public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
		}
	}
}