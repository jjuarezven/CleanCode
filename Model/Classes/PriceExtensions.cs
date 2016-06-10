using System;
using System.ComponentModel;

namespace Model.Classes
{
	public static class PriceExtensions
	{
		public static decimal ApplyDiscountForAccountStatus(this decimal price, decimal discountSize)
		{
			return price - (discountSize * price);
		}

		public static decimal ApplyDiscountForTimeOfHavingAccount(this decimal price, int timeOfHavingAccountInYears)
		{
			decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ? (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100;
			return price - (discountForLoyaltyInPercentage * price);
		}

		public static string GetAttributeDescription(this Enum enumValue)
		{
			var attribute = enumValue.GetAttributeOfType<DescriptionAttribute>();
			return attribute == null ? String.Empty : attribute.Description;
		}

		private static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
		{
			var type = enumVal.GetType();
			var memInfo = type.GetMember(enumVal.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
			return (attributes.Length > 0) ? (T)attributes[0] : null;
		}
	}
}
