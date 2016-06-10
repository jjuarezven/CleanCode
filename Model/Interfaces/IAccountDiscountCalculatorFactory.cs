namespace Model.Interfaces
{
	public interface IAccountDiscountCalculatorFactory
	{
		IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
	}
}
