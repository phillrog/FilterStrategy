using FilterStrategy.Bll.Implementation;
using FilterStrategy.Bll.Interface;
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

		public GenerateInvoiceTest()
		{
			_freightMock = new Mock<IFreight>();
			_genereteInvoice = new GenerateInvoice(_freightMock.Object);
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
