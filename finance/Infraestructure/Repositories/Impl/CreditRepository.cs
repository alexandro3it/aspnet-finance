using ASPFinance.Core.Domains;
using ASPFinance.Model;
using ASPFinance.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPFinance.Infraestructure.Repositories
{
	public sealed class CreditRepository : Repository<ICredit>, ICreditRepository
	{
		public CreditRepository(FinanceContext context)
			: base(context)
		{
		}

		public override ICredit? Get(int? id) => _context.Credits
				.Include(model => model.Customer)
				.AsNoTracking().FirstOrDefault(model => model.Id == id);

		public override async Task<ICredit?> GetAsync(int? id) => await _context.Credits
				.Include(model => model.Customer)
				.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);

		public override IEnumerable<ICredit> GetAll() => _context.Credits
				.Include(model => model.Customer)
				.AsNoTracking().ToList();

		public override async Task<IEnumerable<ICredit>> GetAllAsync() => await _context.Credits
				.Include(model => model.Customer)
				.AsNoTracking().ToListAsync();

		public async Task<IEnumerable<ICredit>> GetAllByDate(DateTime date) => await _context.Credits
				.Where(model => model.CreditDay.Date == date.Date)
				.Include(model => model.Customer)
				.AsNoTracking().ToListAsync();

		public async Task<IEnumerable<ICredit>> GetAllByDateLessThan(DateTime date) => await _context.Credits
				.Where(model => model.CreditDay.Date <= date.Date)
				.Include(model => model.Customer)
				.AsNoTracking().ToListAsync();
	}
}
