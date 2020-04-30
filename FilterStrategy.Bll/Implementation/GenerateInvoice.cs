using FilterStrategy.Bll.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll
{
	public class GenerateInvoice : IGenereateInvoice
	{
		private readonly IFreight _freight;

		public GenerateInvoice(IFreight freight)
		{
			_freight = freight;
		}

		public async Task GenerateAsync(AutomaticBillingCustomerEvent filter)
		{
			/// ... Validations
			
			var freights = await _freight.GenerateFreightsModelForAutomaticBillingAsync(new FreightForBillingFilter { CustomerId = filter.CustomerId });

			if (freights != null && freights.Count > 0)
			{
				List<FreightInvoiceGenerateModel> ableForBilling = new List<FreightInvoiceGenerateModel>();
				List<FreightInvoiceGenerateModel> invalidForBilling = new List<FreightInvoiceGenerateModel>();
			}

			// ... continue process to generate invoice
		}
	}
}
