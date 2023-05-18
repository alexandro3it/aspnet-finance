using ASPFinance.Models;

namespace ASPFinance.Application.Services
{
	public interface IFinanceApplicationServices
	{
		Task<IEnumerable<DailyBalanceViewModel>> GetDailyBalances(DateTime dateBegin, DateTime dateEnd);
	}
}