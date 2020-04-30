using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class FreightInvoiceGenerateModel
	{
		public FreightInvoiceGenerateModel(
			int freightId, int originUnitId, int emissionUnitInt,
			int accountingCompanyOriginUnitId,
			int recipientPersonDetailId, int senderPersonDetailId, int? preInvoiceFreightId = null)
		{
			Freight = freightId;
			OriginUnit = originUnitId;
			EmissionUnit = emissionUnitInt;
			AccountingCompanyOriginUnit = accountingCompanyOriginUnitId;
			RecipientPersonDetail = recipientPersonDetailId;
			SenderPersonDetail = senderPersonDetailId;
			PreInvoiceFreight = preInvoiceFreightId;
		}

		public int? PreInvoiceFreight { get; set; }
		public int Freight { get; set; }
		public int OriginUnit { get; set; }
		public int EmissionUnit { get; set; }
		public int AccountingCompanyOriginUnit { get; set; }
		public int RecipientPersonDetail { get; set; }
		public int SenderPersonDetail { get; set; }
	}
}
