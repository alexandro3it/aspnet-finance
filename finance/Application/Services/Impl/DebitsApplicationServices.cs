using ASPFinance.Infraestructure.Repositories;
using ASPFinance.Model;
using ASPFinance.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPFinance.Application.Services
{
	public sealed class DebitsApplicationServices : IDebitsApplicationServices
	{
		private readonly FinanceContext _context;
		private readonly IDebitRepository _repository;

		public DebitsApplicationServices(FinanceContext context, IDebitRepository repository)
		{
			_context = context;
			_repository = repository;
		}

		public async Task<IDebit?> GetAsync(int? id) => await _repository.GetAsync(id);
		public async Task<IEnumerable<IDebit>> GetAll() => await _repository.GetAllAsync();

		public async Task<IEnumerable<IDebit>> GetAllByDate(DateTime date) => await _context.Debits
			.Where(model => model.DebtDay.Date == date.Date)
			.Include(model => model.Supplier)
			.ToListAsync();

		public async Task<IEnumerable<IDebit>> GetAllByDateLessThan(DateTime date) => await _context.Debits
			.Where(model => model.DebtDay.Date <= date.Date)
			.Include(model => model.Supplier)
			.ToListAsync();

		public Task<IDebit> CreateAsync(IDebit model) => _repository.CreateAsync(model);
		public Task<IDebit> UpdateAsync(IDebit model) => _repository.UpdateAsync(model);
		public Task<IDebit> DeleteAsync(IDebit model) => _repository.DeleteAsync(model);

		public async Task<IEnumerable<Supplier>> GetAllSuppliers() => await _context.Suppliers
			.ToListAsync();
	}
}
