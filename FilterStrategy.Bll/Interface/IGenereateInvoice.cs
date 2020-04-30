using Models;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Interface
{
	public interface IGenereateInvoice
	{
		Task GenerateAsync(AutomaticBillingCustomerEvent filter);
	}
}
