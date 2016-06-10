using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConfiguration
{
	public class CleanCodeContext : DbContext
	{
		public CleanCodeContext() : base()
		{
		}

		public DbSet<DiscountCalculatorConfigurationItem> DiscountCalculatorConfigurationItems { get; set; }
	}
}
