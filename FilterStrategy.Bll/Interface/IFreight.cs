using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Interface
{
	public interface IFreight
	{
		Task<List<FreightInvoiceGenerateModel>> GenerateFreightsModelForAutomaticBillingAsync(FreightForBillingFilter filterModel);
	}
}
