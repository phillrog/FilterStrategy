using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class AutomaticBillingCustomerEvent
	{
		public int CustomerId { get; set; }
		public int BillingId { get; set; }
		public string BillingFrequency { get; set; }
		public string HashReference { get; set; }
		public string Argument { get; set; }
		public long CompanyId { get; set; }
		public string BillingType { get; set; }
	}
}
