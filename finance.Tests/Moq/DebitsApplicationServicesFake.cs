using ASPFinance.Application.Services;
using ASPFinance.Model.Data;

namespace ASPFinance.Tests.Moq;

// TODO - Substituir por Moq
public class DebitsApplicationServicesFake : IDebitsApplicationServices
{
	private readonly IList<IDebit> _collection = new List<IDebit>();
	private readonly List<Supplier> _suppliers = new();

	public DebitsApplicationServicesFake()
	{
		_suppliers.Add(new Supplier() { Id = 1, Name = "Suppliers 1" });

		_collection.Add(new Debit() { Id = 1, Title = "IDebit 1", DebtDay = DateTime.Today, Date = DateTime.Now, Value = 100.00m, SupplierId = 1 });
		_collection.Add(new Debit() { Id = 2, Title = "IDebit 2", DebtDay = DateTime.Today, Date = DateTime.Now, Value = 200.00m, SupplierId = 1 });
		_collection.Add(new Debit() { Id = 3, Title = "IDebit 3", DebtDay = DateTime.Today, Date = DateTime.Now, Value = 300.00m, SupplierId = 1 });
	}

	public Task<IDebit?> GetAsync(int? id) => Task.FromResult(_collection.FirstOrDefault(model => model.Id == id));
	public Task<IEnumerable<IDebit>> GetAll() => Task.FromResult<IEnumerable<IDebit>>(_collection);

	public Task<IEnumerable<IDebit>> GetAllByDate(DateTime date) => Task.FromResult(_collection.Where(model => model.DebtDay == date));
	public Task<IEnumerable<IDebit>> GetAllByDateLessThan(DateTime date) => Task.FromResult(_collection.Where(model => model.DebtDay <= date));

	public Task<IEnumerable<Supplier>> GetAllSuppliers() => Task.FromResult<IEnumerable<Supplier>>(_suppliers);

	public Task<IDebit> CreateAsync(IDebit model)
	{
		if (_collection.Any(r => r.Id == model.Id))
		{
			return Task.FromResult(model);
		}

		_collection.Add(model);
		return Task.FromResult(model);
	}

	public Task<IDebit> DeleteAsync(IDebit model)
	{
		_collection.Remove(model);
		return Task.FromResult(model);
	}

	public Task<IDebit> UpdateAsync(IDebit model)
	{
		if (!_collection.Any(r => r.Id == model.Id))
		{
			return null;
		}

		return Task.FromResult(model);
	}
}
