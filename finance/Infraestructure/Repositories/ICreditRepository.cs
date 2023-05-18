using ASPFinance.Core.Domains;
using ASPFinance.Model.Data;

namespace ASPFinance.Infraestructure.Repositories
{
	public interface ICreditRepository : IRepository<ICredit>
	{
		Task<IEnumerable<ICredit>> GetAllByDate(DateTime date);
		Task<IEnumerable<ICredit>> GetAllByDateLessThan(DateTime date);
	}
}
