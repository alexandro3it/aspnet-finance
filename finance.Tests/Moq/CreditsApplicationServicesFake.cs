using ASPFinance.Application.Services;
using ASPFinance.Model.Data;

namespace ASPFinance.Tests.Moq;

// TODO - Substituir por Moq
public class CreditsApplicationServicesFake : ICreditsApplicationServices
{
	private readonly IList<ICredit> _collection = new List<ICredit>();
	private readonly List<Customer> _customers = new();

	public CreditsApplicationServicesFake()
	{
		_customers.Add(new Customer() { Id = 1, Name = "Customer 1" });

		_collection.Add(new Credit() { Id = 1, Title = "ICredit 1", CreditDay = DateTime.Today, Date = DateTime.Now, Value = 100.00m, CustomerId = 1 });
		_collection.Add(new Credit() { Id = 2, Title = "ICredit 2", CreditDay = DateTime.Today, Date = DateTime.Now, Value = 200.00m, CustomerId = 1 });
		_collection.Add(new Credit() { Id = 3, Title = "ICredit 3", CreditDay = DateTime.Today, Date = DateTime.Now, Value = 300.00m, CustomerId = 1 });
	}

	public Task<ICredit?> GetAsync(int? id) => Task.FromResult(_collection.FirstOrDefault(model => model.Id == id));
	public Task<IEnumerable<ICredit>> GetAll() => Task.FromResult<IEnumerable<ICredit>>(_collection);

	public Task<IEnumerable<ICredit>> GetAllByDate(DateTime date) => Task.FromResult(_collection.Where(model => model.CreditDay == date));
	public Task<IEnumerable<ICredit>> GetAllByDateLessThan(DateTime date) => Task.FromResult(_collection.Where(model => model.CreditDay <= date));

	public Task<IEnumerable<Customer>> GetAllCustomers() => Task.FromResult<IEnumerable<Customer>>(_customers);

	public Task<ICredit> CreateAsync(ICredit model)
	{
		if (_collection.Any(r => r.Id == model.Id))
		{
			return Task.FromResult(model);
		}

		_collection.Add(model);
		return Task.FromResult(model);
	}

	public Task<ICredit> DeleteAsync(ICredit model)
	{
		_collection.Remove(model);
		return Task.FromResult(model);
	}

	public Task<ICredit> UpdateAsync(ICredit model)
	{
		if (!_collection.Any(r => r.Id == model.Id))
		{
			return null;
		}

		return Task.FromResult(model);
	}
}
