using FilterStrategy.Bll.Implementation.FreightValidStrategy;
using FilterStrategy.Bll.Interface;
using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Models.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FilterStrategy.Bll.Test
{
	public class FreightSearchStrategyTest
	{
		private Mock<IFreight> _freight;
		private Mock<ITypeFreightSearch> _lossFreightMock;
		private Mock<ITypeFreightSearch> _validFreightMock;
		private IFreightSearchStrategy _freightSearchStrategy;

		public FreightSearchStrategyTest()
		{
			_freight = new Mock<IFreight>();
			_lossFreightMock = new Mock<ITypeFreightSearch>();
			_validFreightMock = new Mock<ITypeFreightSearch>();
			_freightSearchStrategy = new FreightSearchStrategy(new[]{ _lossFreightMock.Object , _validFreightMock.Object });
		}

		[Fact]
		public void Deve_Encontrar_Fretes_Situacao_Perda()
		{
			var filter = new List<FreightInvoiceGenerateModel>() {
				new FreightInvoiceGenerateModel(1, 2, 3, 4, 5, 6)
			};
			var (expectedResultA, expectedResultB) = (new List<FreightInvoiceGenerateModel> { new FreightInvoiceGenerateModel(1,2,3,4,5,6)}, 
													 new List<FreightInvoiceGenerateModel> { new FreightInvoiceGenerateModel(7, 8, 9, 10, 11, 12) });

			_lossFreightMock.Setup(a => a.Frequency).Returns(new List<BillingScheduleFrequencyEnum> { BillingScheduleFrequencyEnum.None });
			_lossFreightMock.Setup(a => a.Type).Returns(new List<BillingScheduleTypeEnum> { BillingScheduleTypeEnum.AutomaticLoss });
			_lossFreightMock.Setup(a => a.FindAsync(filter)).ReturnsAsync((expectedResultA, expectedResultB));

			var (resultA, resultB) = _freightSearchStrategy.FindAsync(filter, BillingScheduleFrequencyEnum.None, BillingScheduleTypeEnum.AutomaticLoss).GetAwaiter().GetResult();

			Assert.True(resultA.Count > 0 && resultB.Count > 0); 
		}

		[Fact]
		public void Deve_Encontrar_Fretes_Validos()
		{
			var filter = new List<FreightInvoiceGenerateModel>() {
				new FreightInvoiceGenerateModel(1, 2, 3, 4, 5, 6)
			};

			var (expectedResultA, expectedResultB) = (new List<FreightInvoiceGenerateModel> { new FreightInvoiceGenerateModel(1, 2, 3, 4, 5, 6) },
													 new List<FreightInvoiceGenerateModel> { new FreightInvoiceGenerateModel(7, 8, 9, 10, 11, 12) });

			_validFreightMock.Setup(a => a.Frequency).Returns(new List<BillingScheduleFrequencyEnum> { BillingScheduleFrequencyEnum.None });
			_validFreightMock.Setup(a => a.Type).Returns(new List<BillingScheduleTypeEnum> { BillingScheduleTypeEnum.AutomaticLoss });
			_validFreightMock.Setup(a => a.FindAsync(filter)).ReturnsAsync((expectedResultA, expectedResultB));

			var (resultA, resultB) = _freightSearchStrategy.FindAsync(filter,BillingScheduleFrequencyEnum.Programming, BillingScheduleTypeEnum.Automatic).GetAwaiter().GetResult();

			Assert.True(resultA.Count > 0 && resultB.Count > 0);
		}
	}
}
