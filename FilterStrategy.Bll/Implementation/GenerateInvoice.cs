using FilterStrategy.Bll.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilterStrategy.Bll
{
	public class GenerateInvoice
	{
		private readonly IFreight _freight;

		public GenerateInvoice(IFreight freight)
		{
			_freight = freight;
		}
	}
}
