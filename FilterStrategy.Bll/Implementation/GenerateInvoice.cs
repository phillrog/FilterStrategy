using FilterStrategy.Bll.Interface;
using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation
{
	public class GenerateInvoice : IGenereteInvoice
	{
		private readonly IFreight _freight;
		private readonly IFreightSearchStrategy _freightSearchStrategy;

		public GenerateInvoice(IFreight freight, IFreightSearchStrategy freightSearchStrategy)
		{
			_freight = freight;
			_freightSearchStrategy = freightSearchStrategy;
		}

		public async Task GenerateAsync(AutomaticBillingCustomerEvent filter)
		{
			/// ... Validations
			
			var freights = await _freight.GenerateFreightsModelForAutomaticBillingAsync(new FreightForBillingFilter { CustomerId = filter.CustomerId });

			if (freights != null && freights.Count > 0)
			{
				var (ableForBilling, invalidForBilling) = await _freightSearchStrategy.FindAsync(
					(BillingScheduleFrequencyEnum)Enum.Parse(typeof(BillingScheduleFrequencyEnum), filter.BillingFrequency),
					(BillingScheduleTypeEnum)Enum.Parse(typeof(BillingScheduleTypeEnum), filter.BillingType));
			}

			// ... continue process to generate invoice
		}
	}
}
