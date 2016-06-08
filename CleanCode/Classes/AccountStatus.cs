using System.ComponentModel;

public enum AccountStatus
{
	[Description("Not Registered")]
	NotRegistered = 1,
	[Description("Simple Customer")]
	SimpleCustomer = 2,
	[Description("Valuable Customer")]
	ValuableCustomer = 3,
	[Description("Most Valuable Customer")]
	MostValuableCustomer = 4
}