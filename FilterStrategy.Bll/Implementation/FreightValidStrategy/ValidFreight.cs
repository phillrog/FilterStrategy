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

		public BillingScheduleFrequencyEnum Frequency => Enum.GetValues(typeof(BillingScheduleFrequencyEnum))
																.Cast<BillingScheduleFrequencyEnum>()
																.FirstOrDefault(a => !a.Equals(BillingScheduleFrequencyEnum.None));

		public BillingScheduleTypeEnum Type => Enum.GetValues(typeof(BillingScheduleTypeEnum))
																.Cast<BillingScheduleTypeEnum>()
																.FirstOrDefault(a => !a.Equals(BillingScheduleTypeEnum.AutomaticLoss));
		public ValidFreight(IFreight freight )
		{
			_freight = freight;
		}

		public async Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync()
		{
			return await _freight.Valids();
		}
	}
}
