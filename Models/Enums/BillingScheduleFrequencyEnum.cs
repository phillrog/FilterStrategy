using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Enums
{
	public enum BillingScheduleFrequencyEnum
	{
		[Display(Name = "Diário")]
		Daily = 1,

		[Display(Name = "Semanal")]
		Weekly = 2,

		[Display(Name = "Mensal")]
		Monthly = 4,

		[Display(Name = "Programação Faturamento")]
		Programming = 6,
	}
}
