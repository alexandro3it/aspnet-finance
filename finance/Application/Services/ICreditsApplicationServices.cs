using ASPFinance.Model.Data;

namespace ASPFinance.Application.Services
{
	public interface ICreditsApplicationServices
	{
		Task<ICredit?> GetAsync(int? id);
		Task<IEnumerable<ICredit>> GetAll();
		Task<IEnumerable<ICredit>> GetAllByDate(DateTime date);
		Task<IEnumerable<ICredit>> GetAllByDateLessThan(DateTime date);
		Task<ICredit> CreateAsync(ICredit model);
		Task<ICredit> UpdateAsync(ICredit model);
		Task<ICredit> DeleteAsync(ICredit model);
		Task<IEnumerable<Customer>> GetAllCustomers();
	}
}