using ASPFinance.Infraestructure.Repositories;
using ASPFinance.Model;
using ASPFinance.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPFinance.Application.Services
{
	public sealed class CreditsApplicationServices : ICreditsApplicationServices
	{
		private readonly FinanceContext _context;
		private readonly ICreditRepository _repository;

		public CreditsApplicationServices(FinanceContext context, ICreditRepository repository)
		{
			_context = context;
			_repository = repository;
		}

		public async Task<ICredit?> GetAsync(int? id) => await _repository.GetAsync(id);
		public async Task<IEnumerable<ICredit>> GetAll() => await _repository.GetAllAsync();

		public async Task<IEnumerable<ICredit>> GetAllByDate(DateTime date) => await _context.Credits
			.Where(model => model.CreditDay.Date == date.Date)
			.Include(model => model.Customer)
			.ToListAsync();

		public async Task<IEnumerable<ICredit>> GetAllByDateLessThan(DateTime date) => await _context.Credits
			.Where(model => model.CreditDay.Date <= date.Date)
			.Include(model => model.Customer)
			.ToListAsync();

		public Task<ICredit> CreateAsync(ICredit model) => _repository.CreateAsync(model);
		public Task<ICredit> UpdateAsync(ICredit model) => _repository.UpdateAsync(model);
		public Task<ICredit> DeleteAsync(ICredit model) => _repository.DeleteAsync(model);

		public async Task<IEnumerable<Customer>> GetAllCustomers() => await _context.Customers
			.ToListAsync();
	}
}
