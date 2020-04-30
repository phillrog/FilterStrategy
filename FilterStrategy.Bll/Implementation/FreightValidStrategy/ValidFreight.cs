using FilterStrategy.Bll.Interface;
using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation.FreightValidStrategy
{
	public class ValidFreight : ITypeFreightSearch
	{
		private readonly IFreight _freight;

		public List<BillingScheduleFrequencyEnum> Frequency => Enum.GetValues(typeof(BillingScheduleFrequencyEnum))
																.Cast<BillingScheduleFrequencyEnum>()
																.Where(a => !a.Equals(BillingScheduleFrequencyEnum.None))
																.ToList();

		public List<BillingScheduleTypeEnum> Type => Enum.GetValues(typeof(BillingScheduleTypeEnum))
																.Cast<BillingScheduleTypeEnum>()
																.Where(a => !a.Equals(BillingScheduleTypeEnum.AutomaticLoss))
																.ToList();
		public ValidFreight(IFreight freight )
		{
			_freight = freight;
		}

		public async Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync(List<FreightInvoiceGenerateModel> filter)
		{
			return await _freight.Valids(filter);
		}
	}
}
