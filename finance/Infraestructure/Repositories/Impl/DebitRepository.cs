using ASPFinance.Core.Domains;
using ASPFinance.Model;
using ASPFinance.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPFinance.Infraestructure.Repositories
{
	public sealed class DebitRepository : Repository<IDebit>, IDebitRepository
	{
		public DebitRepository(FinanceContext context)
			: base(context)
		{
		}

		public override IDebit? Get(int? id) => _context.Debits
				.Include(model => model.Supplier)
				.AsNoTracking().FirstOrDefault(model => model.Id == id);

		public override async Task<IDebit?> GetAsync(int? id) => await _context.Debits
				.Include(model => model.Supplier)
				.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);

		public override IEnumerable<IDebit> GetAll() => _context.Debits
				.Include(model => model.Supplier)
				.AsNoTracking().ToList();

		public override async Task<IEnumerable<IDebit>> GetAllAsync() => await _context.Debits
				.Include(model => model.Supplier)
				.AsNoTracking().ToListAsync();

		public async Task<IEnumerable<IDebit>> GetAllByDate(DateTime date) => await _context.Debits
				.Where(model => model.DebtDay.Date == date.Date)
				.Include(model => model.Supplier)
				.AsNoTracking().ToListAsync();

		public async Task<IEnumerable<IDebit>> GetAllByDateLessThan(DateTime date) => await _context.Debits
				.Where(model => model.DebtDay.Date <= date.Date)
				.Include(model => model.Supplier)
				.AsNoTracking().ToListAsync();
	}
}
