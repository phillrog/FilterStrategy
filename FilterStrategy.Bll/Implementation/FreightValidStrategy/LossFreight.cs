using FilterStrategy.Bll.Interface;
using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation.FreightValidStrategy
{
	public class LossFreight : ITypeFreightSearch
	{
		private readonly IFreight _freight;

		public BillingScheduleFrequencyEnum Frequency => BillingScheduleFrequencyEnum.None;

		public BillingScheduleTypeEnum Type => BillingScheduleTypeEnum.AutomaticLoss;

		public LossFreight(IFreight freight)
		{
			_freight = freight;
		}

		public async Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync()
		{
			return await _freight.Loss();
		}
	}
}
