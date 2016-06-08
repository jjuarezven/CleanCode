namespace CleanCode.Interfaces
{
	public interface IAccountDiscountCalculatorFactory
	{
		IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
	}
}
