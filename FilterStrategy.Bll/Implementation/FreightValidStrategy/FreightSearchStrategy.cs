using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation.FreightValidStrategy
{
	public class FreightSearchStrategy : IFreightSearchStrategy
	{
		private readonly IEnumerable<ITypeFreightSearch> _typeSearch;

		public FreightSearchStrategy(IEnumerable<ITypeFreightSearch> typeSearch)
		{
			_typeSearch = typeSearch;
		}

		public async Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> FindAsync(List<FreightInvoiceGenerateModel> filter, 
			BillingScheduleFrequencyEnum frequency, BillingScheduleTypeEnum type)
		{
			return await _typeSearch.Single(t => t.Frequency.Contains(frequency) && t.Type.Contains(type)).FindAsync(filter);
		}
	}
}
