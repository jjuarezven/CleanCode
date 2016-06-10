using Model;
using System.ComponentModel.DataAnnotations;

namespace DataBaseConfiguration
{
	public class DiscountCalculatorConfigurationItem
	{
		[Key]
		public AccountStatus AccountStatus { get; set; }
		public string Implementation { get; set; }
	}
}
