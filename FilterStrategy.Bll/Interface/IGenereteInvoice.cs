using Models;
using System.Threading.Tasks;

namespace FilterStrategy.Bll.Interface
{
	public interface IGenereteInvoice
	{
		Task GenerateAsync(AutomaticBillingCustomerEvent filter);
	}
}
