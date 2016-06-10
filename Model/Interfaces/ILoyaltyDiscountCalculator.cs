namespace Model.Interfaces
{
	public interface ILoyaltyDiscountCalculator
	{
		decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
	}
}
