using ASPFinance.Application.Services;
using ASPFinance.Tests.Moq;

namespace ASPFinance.Tests.ApplicationsServices
{
	[TestClass]
	public class FinanceApplicationServicesTest
	{
		private IFinanceApplicationServices _services;
		private IDebitsApplicationServices _debits;
		private ICreditsApplicationServices _credits;

		public TestContext TestContext { get; set; }

		[TestInitialize]
		public void Initialize()
		{
			_credits = new CreditsApplicationServicesFake();
			_debits = new DebitsApplicationServicesFake();
			_services = new FinanceApplicationServices(_credits, _debits);
		}

		[TestCleanup]
		public void Cleanup()
		{
		}

		[TestMethod("GetDailyBalances - Total de lançamentos")]
		[TestCategory("Finance Application Services")]
		[Priority(1)]
		[Owner("Alexandro Ribeiro")]
		[Timeout(500)]
		public void GetDailyBalancesCountTest()
		{
			TestContext.WriteLine($"{TestContext.TestName}");

			TestContext.WriteLine($"Result");
			IEnumerable<Models.DailyBalanceViewModel> result = _services.GetDailyBalances(DateTime.Today, DateTime.Today).Result;

			TestContext.WriteLine("I - Count");
			Assert.AreEqual(1, result.Count());
		}
		
		[TestMethod("GetDailyBalances - Soma dos créditos")]
		[TestCategory("Finance Application Services")]
		[Priority(2)]
		[Owner("Alexandro Ribeiro")]
		[Timeout(500)]
		public void GetDailyBalancesSumCreditsTest()
		{
			TestContext.WriteLine($"{TestContext.TestName}");

			TestContext.WriteLine($"Result");
			IEnumerable<Models.DailyBalanceViewModel> result = _services.GetDailyBalances(DateTime.Today, DateTime.Today).Result;

			TestContext.WriteLine("I - AreEqual");
			decimal credits = _credits.GetAll().Result.Sum(model => model.Value);
			decimal totalInput = result.Sum(model => model.TotalInput);
			Assert.AreEqual(credits, totalInput);
		}

		[TestMethod("GetDailyBalances - Soma dos débitos")]
		[TestCategory("Finance Application Services")]
		[Priority(3)]
		[Owner("Alexandro Ribeiro")]
		[Timeout(500)]
		public void GetDailyBalancesSumDebitsTest()
		{
			TestContext.WriteLine($"{TestContext.TestName}");

			TestContext.WriteLine($"Result");
			IEnumerable<Models.DailyBalanceViewModel> result = _services.GetDailyBalances(DateTime.Today, DateTime.Today).Result;

			TestContext.WriteLine("I - AreEqual");
			decimal debits = _credits.GetAll().Result.Sum(model => model.Value);
			decimal totalOutput = result.Sum(model => model.TotalOutput);
			Assert.AreEqual(debits, totalOutput);

		}

		[TestMethod("GetDailyBalances - Saldo final")]
		[TestCategory("Finance Application Services")]
		[Priority(4)]
		[Owner("Alexandro Ribeiro")]
		[Timeout(500)]
		public void GetDailyBalancesFinalBalanceTest()
		{
			TestContext.WriteLine($"{TestContext.TestName}");

			TestContext.WriteLine($"Result");
			IEnumerable<Models.DailyBalanceViewModel> result = _services.GetDailyBalances(DateTime.Today, DateTime.Today).Result;

			TestContext.WriteLine("I - AreEqual");
			decimal credits = _credits.GetAll().Result.Sum(model => model.Value);
			decimal debits = _credits.GetAll().Result.Sum(model => model.Value);
			Assert.AreEqual(credits - debits, result.Sum(model => model.FinalBalance));
		}
	}	
}
