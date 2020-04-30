using FilterStrategy.Bll.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation
{
	public class Freight : IFreight
	{
		public Task<List<FreightInvoiceGenerateModel>> GenerateFreightsModelForAutomaticBillingAsync(FreightForBillingFilter filterModel)
		{
			throw new NotImplementedException();
		}
	}
}
