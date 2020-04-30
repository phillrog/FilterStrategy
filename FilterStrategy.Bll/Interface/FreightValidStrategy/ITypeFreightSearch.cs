using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Interface.FreightValidStrategy
{
	public interface ITypeFreightSearch
	{
		List<BillingScheduleFrequencyEnum> Frequency { get; }
		List<BillingScheduleTypeEnum> Type { get; }
		Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync(List<FreightInvoiceGenerateModel> filter);
	}
}
