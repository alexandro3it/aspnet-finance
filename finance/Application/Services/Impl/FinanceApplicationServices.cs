using ASPFinance.Models;

namespace ASPFinance.Application.Services
{
	public sealed class FinanceApplicationServices : IFinanceApplicationServices
	{
		private readonly IDebitsApplicationServices _debits;
		private readonly ICreditsApplicationServices _credits;

		public FinanceApplicationServices(ICreditsApplicationServices credits, IDebitsApplicationServices debits)
		{
			_debits = debits;
			_credits = credits;
		}

		public async Task<IEnumerable<DailyBalanceViewModel>> GetDailyBalances(DateTime dateBegin, DateTime dateEnd)
		{
			List<DailyBalanceViewModel> result = new();
			await AddRange(await AddPreviousValues(result, dateBegin.AddDays(-1)), result, dateBegin, dateEnd);
			return result;
		}

		private async Task AddRange(decimal previousValue, List<DailyBalanceViewModel> collection, DateTime dateBegin, DateTime dateEnd)
		{
			collection.Clear();
			DateTime currentDate = dateBegin;
			do
			{
				previousValue = await AddDate(previousValue, collection, currentDate);
				currentDate = currentDate.AddDays(1);
			} while (currentDate.Date <= dateEnd.Date);
		}

		private async Task<decimal> AddDate(decimal previousValue, List<DailyBalanceViewModel> collection, DateTime currentDate)
		{
			decimal totalInput = (await _credits.GetAllByDate(currentDate)).Sum(model => model.Value);
			decimal totalOutput = (await _debits.GetAllByDate(currentDate)).Sum(model => model.Value);
			decimal finalBalance = totalInput - totalOutput;

			collection.Add(new DailyBalanceViewModel()
			{
				Date = currentDate.Date,
				PreviousValue = previousValue,
				TotalInput = totalInput,
				TotalOutput = totalOutput,
				FinalBalance = previousValue + finalBalance
			});

			previousValue += finalBalance;
			return previousValue;
		}

		private async Task<decimal> AddPreviousValues(List<DailyBalanceViewModel> collection, DateTime previousDate)
		{
			IEnumerable<Model.Data.IDebit> previousDebit = await _debits.GetAllByDateLessThan(previousDate);
			IEnumerable<Model.Data.ICredit> previousCredit = await _credits.GetAllByDateLessThan(previousDate);
			DailyBalanceViewModel result;
			collection.Add(result = new DailyBalanceViewModel()
			{
				Date = previousDate,
				PreviousValue = previousCredit.Sum(x => x.Value) - previousDebit.Sum(x => x.Value)
			});

			return result.PreviousValue;
		}
	}
}
