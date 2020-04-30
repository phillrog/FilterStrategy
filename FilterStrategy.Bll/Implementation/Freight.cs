using FilterStrategy.Bll.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Implementation
{
	public class Freight : IFreight
	{
		public Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> Valids(List<FreightInvoiceGenerateModel> freights)
		{
			return Task.Run(() =>
			{
				return (freights.Where(x => x.OriginUnit == 11 && x.EmissionUnit == 11).ToList(), freights.Where(d => d.AccountingCompanyOriginUnit == 4).ToList());
			});
		}

		public Task<List<FreightInvoiceGenerateModel>> GenerateFreightsModelForAutomaticBillingAsync(FreightForBillingFilter filterModel)
		{
			return Task.Run(() =>
			{
				return new List<FreightInvoiceGenerateModel> {
					new FreightInvoiceGenerateModel(1, 11, 41, 4, 1, 1),
					new FreightInvoiceGenerateModel(2, 2, 1, 1, 4, 1),
					new FreightInvoiceGenerateModel(3, 4, 1, 21, 21, 1),
					new FreightInvoiceGenerateModel(4, 999,21, 34, 1, 1),
					new FreightInvoiceGenerateModel(5, 1, 1, 1,31, 1),
					new FreightInvoiceGenerateModel(6, 11, 11, 12, 1, 1),
					new FreightInvoiceGenerateModel(7, 123, 13, 1, 1, 21),
					new FreightInvoiceGenerateModel(8, 11, 1000, 1, 1, 41),
					new FreightInvoiceGenerateModel(9, 14, 9, 1, 41, 9),
					new FreightInvoiceGenerateModel(10, 412, 5, 13, 14, 9)
				};
			});
		}

		public Task<(List<FreightInvoiceGenerateModel>, List<FreightInvoiceGenerateModel>)> Loss(List<FreightInvoiceGenerateModel> freights)
		{
			return Task.Run(() =>
			{
				return (freights.Where(x => x.OriginUnit != 11 && x.EmissionUnit != 11).ToList(), freights.Where(d => d.AccountingCompanyOriginUnit != 4).ToList());
			});
		}
	}
}
