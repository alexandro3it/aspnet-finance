using ASPFinance.Core.ORM;

namespace ASPFinance.Core.Domains
{
	public interface IRepository<T>
		where T : IAgregateRoot, IPersistentObject
	{
		T? Get(int? id);
		Task<T?> GetAsync(int? id);
		IEnumerable<T> GetAll();
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> CreateAsync(T model);
		Task<T> UpdateAsync(T model);
		Task<T> DeleteAsync(T model);
	}
}
