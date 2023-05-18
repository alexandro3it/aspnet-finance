using ASPFinance.Model.Data;

namespace ASPFinance.Application.Services
{
	public interface IDebitsApplicationServices
	{
		Task<IDebit?> GetAsync(int? id);
		Task<IEnumerable<IDebit>> GetAll();
		Task<IEnumerable<IDebit>> GetAllByDate(DateTime date);
		Task<IEnumerable<IDebit>> GetAllByDateLessThan(DateTime date);
		Task<IDebit> CreateAsync(IDebit model);
		Task<IDebit> UpdateAsync(IDebit model);
		Task<IDebit> DeleteAsync(IDebit model);
		Task<IEnumerable<Supplier>> GetAllSuppliers();
	}
}