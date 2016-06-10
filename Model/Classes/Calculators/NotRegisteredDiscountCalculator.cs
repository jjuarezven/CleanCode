using Model.Interfaces;

namespace Model.Classes.Calculators
{
	public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
	{
		public decimal ApplyDiscount(decimal price)
		{
			return price;
		}
	}
}