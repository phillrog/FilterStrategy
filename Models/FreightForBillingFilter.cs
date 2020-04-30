using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class FreightForBillingFilter
	{		
		public List<int> UnitIds { get; set; }
		public BillingScheduleFrequencyEnum? Frequency { get; set; }
		public List<int> FreightIds { get; set; }
		public int CustomerId { get; set; }
		public DateTime? InitialEmissionDate { get; set; }
		public DateTime? FinalEmissionDate { get; set; }
		public int? PreInvoiceId { get; set; }
		public bool UseFreightSubstitute { get; set; } = false;
		public bool ActiveBillingResearch { get; set; }
		public BillingScheduleTypeEnum? Type { get; set; }
	}
}
