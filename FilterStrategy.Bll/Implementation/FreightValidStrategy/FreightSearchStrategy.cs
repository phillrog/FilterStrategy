using FilterStrategy.Bll.Interface.FreightValidStrategy;
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

		public Task Find(BillingScheduleFrequencyEnum frequency, BillingScheduleTypeEnum type)
		{
			return _typeSearch.Single(t => t.Frequency == frequency && t.Type == type).Find();
		}
	}
}
