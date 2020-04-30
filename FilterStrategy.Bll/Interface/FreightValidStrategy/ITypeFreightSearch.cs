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
		public BillingScheduleFrequencyEnum Frequency { get; }
		public BillingScheduleTypeEnum Type { get; }
		Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync();
	}
}
