using Model.Interfaces;

namespace Model.Classes.Calculators
{
	public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
		}
	}
}