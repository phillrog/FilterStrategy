using FilterStrategy.Bll.Interface;
using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation.FreightValidStrategy
{
	public class LossFreight : ITypeFreightSearch
	{
		private readonly IFreight _freight;

		public List<BillingScheduleFrequencyEnum> Frequency => Enum.GetValues(typeof(BillingScheduleFrequencyEnum))
																.Cast<BillingScheduleFrequencyEnum>()
																.Where(a => a.Equals(BillingScheduleFrequencyEnum.None))
																.ToList();

		public List<BillingScheduleTypeEnum> Type => Enum.GetValues(typeof(BillingScheduleTypeEnum))
																.Cast<BillingScheduleTypeEnum>()
																.Where(a => a.Equals(BillingScheduleTypeEnum.AutomaticLoss))
																.ToList();

		public LossFreight(IFreight freight)
		{
			_freight = freight;
		}

		public async Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync(List<FreightInvoiceGenerateModel> filter)
		{
			if (filter.Count == 0)
				throw new Exception("Informe um filtro");
			return await _freight.Loss(filter);
		}
	}
}
