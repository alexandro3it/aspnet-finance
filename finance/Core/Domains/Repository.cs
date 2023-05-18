using ASPFinance.Core.ORM;
using ASPFinance.Model;

namespace ASPFinance.Core.Domains
{
	public abstract class Repository<T> : IRepository<T>
		where T : class, IAgregateRoot, IPersistentObject
	{
		protected readonly FinanceContext _context;

		protected Repository(FinanceContext context)
		{
			_context = context;
		}

		public virtual T? Get(int? id) => _context.Find<T>(id);
		public virtual async Task<T?> GetAsync(int? id) => await _context.FindAsync<T>(id);

		public abstract IEnumerable<T> GetAll();
		public abstract Task<IEnumerable<T>> GetAllAsync();

		public virtual T BeforeCreate(T model) => model;
		public async Task<T> CreateAsync(T model)
		{
			model = BeforeCreate(model);
			model = _context.Add(model)
				.Entity;
			await _context.SaveChangesAsync();
			return model;
		}

		public virtual T BeforeUpdate(T model) => model;
		public async Task<T> UpdateAsync(T model)
		{
			model = BeforeUpdate(model);
			model = _context.Update(model)
				.Entity;
			await _context.SaveChangesAsync();
			return model;
		}

		public virtual T BeforeDelete(T model) => model;
		public async Task<T> DeleteAsync(T model)
		{
			model = BeforeDelete(model);
			model = _context.Remove(model)
				.Entity;
			await _context.SaveChangesAsync();
			return model;
		}
	}
}
