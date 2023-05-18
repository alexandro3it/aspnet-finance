using ASPFinance.Core.Domains;
using ASPFinance.Model.Data;

namespace ASPFinance.Infraestructure.Repositories
{
	public interface IDebitRepository : IRepository<IDebit>
	{
		Task<IEnumerable<IDebit>> GetAllByDate(DateTime date);
		Task<IEnumerable<IDebit>> GetAllByDateLessThan(DateTime date);
	}
}
