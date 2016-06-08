using CleanCode.Interfaces;

namespace CleanCode.Classes
{
	public class DiscountManager
	{
		private readonly IAccountDiscountCalculatorFactory _factory;
		private readonly ILoyaltyDiscountCalculator _loyaltyDiscountCalculator;

		public DiscountManager(IAccountDiscountCalculatorFactory factory, ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
		{
			_factory = factory;
			_loyaltyDiscountCalculator = loyaltyDiscountCalculator;
		}

		public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
		{
			decimal priceAfterDiscount = 0;
			#region old code
			//switch (accountStatus)
			//{
			//	case AccountStatus.NotRegistered:
			//	priceAfterDiscount = price;
			//	break;
			//	case AccountStatus.SimpleCustomer:
			//	priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS);
			//	break;
			//	case AccountStatus.ValuableCustomer:
			//	priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS);
			//	break;
			//	case AccountStatus.MostValuableCustomer:
			//	priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS);
			//	break;
			//	default:
			//	throw new NotImplementedException();
			//}
			//priceAfterDiscount = priceAfterDiscount.ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears); 
			#endregion

			priceAfterDiscount = _factory.GetAccountDiscountCalculator(accountStatus).ApplyDiscount(price);
			priceAfterDiscount = _loyaltyDiscountCalculator.ApplyDiscount(priceAfterDiscount, timeOfHavingAccountInYears);
			return priceAfterDiscount;
		}
	}
}
