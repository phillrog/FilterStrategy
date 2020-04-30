using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Enums
{
	public enum BillingScheduleTypeEnum
	{
		[Display(Name = "Manual")]
		Manual = 1,

		[Display(Name = "Automático")]
		Automatic = 2,

		[Display(Name = "Perda")]
		AutomaticLoss = 3
	}
}
