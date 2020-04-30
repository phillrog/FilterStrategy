using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Interface.FreightValidStrategy
{
	public interface IFreightSearchStrategy
	{
		Task Find(BillingScheduleFrequencyEnum frequency, BillingScheduleTypeEnum type);
	}
}
