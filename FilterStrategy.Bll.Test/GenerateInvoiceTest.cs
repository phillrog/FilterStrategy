using FilterStrategy.Bll.Implementation;
using FilterStrategy.Bll.Interface;
using FilterStrategy.Bll.Interface.FreightValidStrategy;
using Models;
using Moq;
using System;
using Xunit;

namespace FilterStrategy.Bll.Test
{
	public class GenerateInvoiceTest
	{
		private Mock<IFreight> _freightMock;
		private GenerateInvoice _genereteInvoice;
		private Mock<IFreightSearchStrategy> _freightSearchStrategyMock;

		public GenerateInvoiceTest()
		{
			_freightMock = new Mock<IFreight>();
			_freightSearchStrategyMock = new Mock<IFreightSearchStrategy>();
			_genereteInvoice = new GenerateInvoice(_freightMock.Object, _freightSearchStrategyMock.Object);
		}

		[Fact]
		public void Deve_Gerar_Fatura()
		{
			var messageEvent = new AutomaticBillingCustomerEvent {
				BillingFrequency = "0",
				BillingType = "2"
			};
			_genereteInvoice.GenerateAsync(messageEvent).GetAwaiter().GetResult();
		}
	}
}
