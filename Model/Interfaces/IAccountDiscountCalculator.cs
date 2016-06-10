namespace Model.Interfaces
{
	public interface IAccountDiscountCalculator
	{
		decimal ApplyDiscount(decimal price);
	}
}
