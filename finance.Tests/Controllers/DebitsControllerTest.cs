using ASPFinance.Application.Services;
using ASPFinance.Controllers;
using ASPFinance.Model.Data;
using ASPFinance.Model.Mapping;
using ASPFinance.Models;
using ASPFinance.Tests.Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ASPFinance.Tests.Controllers;

[TestClass]
public class DebitsControllerTest
{
	private const string Key = "Title";
	private const string ErrorMessage = "Inválid Title";

	private IMapper _mapper;
	private IDebitsApplicationServices _services;

	private Debit _model;
	private DebitsController _controller;

	public TestContext TestContext { get; set; }

	[TestInitialize]
	public void Initialize()
	{
		_mapper = Mapping.RegisterMaps().CreateMapper();

		_model = NewDebit();
		_controller = new DebitsController(_mapper, _services = new DebitsApplicationServicesFake());
		_services.CreateAsync(_model);
	}

	[TestCleanup]
	public void Cleanup()
	{
	}

	private static Debit NewDebit(int id = 99) => new()
	{
		Id = id,
		Title = "Test",
		Descripton = "Test",
		DebtDay = DateTime.Today,
		Value = 1,
		SupplierId = 1
	};	

	[TestMethod("GetAll")]
	[TestCategory("Debits Controller")]
	[Priority(9)]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void GetAllTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.Index().Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		Assert.IsInstanceOfType(result, typeof(ViewResult));
		ViewResult? viewResult = result as ViewResult;
		TestContext.WriteLine("II - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(viewResult);
		Assert.IsInstanceOfType(viewResult.Model, typeof(List<DebitViewModel>));
		IEnumerable<DebitViewModel>? viewModel = viewResult.Model as IEnumerable<DebitViewModel>;
		TestContext.WriteLine("III - IsNotNull");
		Assert.IsNotNull(viewModel);
		TestContext.WriteLine("IV - Count");
		Assert.AreEqual(4, viewModel.Count());
	}

	[TestMethod("CreateNewDebit")]
	[TestCategory("Debits Controller")]
	[Priority(1)]
	[Description("Teste de Inclusão de um novo registro de Débito")]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void CreateNewDebitTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.Create(NewDebit(1000)).Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
		TestContext.WriteLine("II - Count");
		Assert.AreEqual(5, _services.GetAll().Result.Count());
	}

	[TestMethod("CreateNewDebit(Fail)")]
	[TestCategory("Debits Controller")]
	[Priority(1)]
	[Description("Teste de Falha de Inclusão de um novo registro de Débito")]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void CreateNewDebitFailTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine("Create(Fail)");

		TestContext.WriteLine($"{Key} - {ErrorMessage}");
		_controller.ModelState.AddModelError(Key, ErrorMessage);

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.Create(_model).Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		Assert.IsInstanceOfType(result, typeof(ViewResult));
		ViewResult? viewResult = result as ViewResult;
		TestContext.WriteLine("II - IsNotNull");
		Assert.IsNotNull(viewResult);
		ViewDataDictionary viewData = viewResult.ViewData;
		TestContext.WriteLine("III - AreNotEqual && IsTrue");
		Assert.AreNotEqual(viewData.ModelState.Count, 0);
		Assert.IsTrue(viewData.ModelState.ContainsKey(Key));
		TestContext.WriteLine("IV - IsNotNull && AreNotEqual");
		viewData.ModelState.TryGetValue(Key, out ModelStateEntry? value);
		Assert.IsNotNull(value);
		Assert.AreEqual(value.Errors[0].ErrorMessage, ErrorMessage);
		Assert.AreEqual(viewResult.Model, _model);
	}

	[TestMethod("Update Debit")]
	[TestCategory("Debits Controller")]
	[Priority(2)]
	[Description("Teste de Alteração de um novo registro de Débito")]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void UpdateDebitTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.Edit(_model.Id, _model).Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
		TestContext.WriteLine("II - Count");
		Assert.AreEqual(4, _services.GetAll().Result.Count());
	}

	[TestMethod("Update Debit(Fail)")]
	[TestCategory("Debits Controller")]
	[Priority(2)]
	[Description("Teste de Falha de Alteração de um novo registro de Débito")]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void UpdateDebitFailTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine($"Delete");
		_services.DeleteAsync(_model);

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.Edit(_model.Id, _model).Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		TestContext.WriteLine("II - IsNotNull && IsInstanceOfType");
		NotFoundResult? notFound = result as NotFoundResult;
		Assert.IsNotNull(notFound);
		Assert.IsInstanceOfType(notFound, typeof(NotFoundResult));
		TestContext.WriteLine("III - AreEqual");
		Assert.AreEqual(404, notFound.StatusCode);
	}

	[TestMethod("Delete Debit(Fail)")]
	[TestCategory("Debits Controller")]
	[Priority(3)]
	[Description("Teste de Exclusão de um novo registro de Débito")]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void DeleteDebitTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.DeleteConfirmed(_model.Id).Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
		TestContext.WriteLine("II - Count");
		Assert.AreEqual(3, _services.GetAll().Result.Count());
	}

	[TestMethod("Delete Debit(Fail)")]
	[Priority(3)]
	[TestCategory("Debits Controller")]
	[Description("Teste de Falha de Exclusão de um novo registro de Débito")]
	[Owner("Alexandro Ribeiro")]
	[Timeout(500)]
	public void DeleteDebitFailTest()
	{
		TestContext.WriteLine($"{TestContext.TestName}");

		TestContext.WriteLine($"Delete");
		_services.DeleteAsync(_model);

		TestContext.WriteLine($"Result");
		IActionResult result = _controller.DeleteConfirmed(_model.Id).Result;
		TestContext.WriteLine("I - IsNotNull && IsInstanceOfType");
		Assert.IsNotNull(result);
		TestContext.WriteLine("II - IsNotNull && IsInstanceOfType");
		NotFoundResult? notFound = result as NotFoundResult;
		Assert.IsNotNull(notFound);
		Assert.IsInstanceOfType(notFound, typeof(NotFoundResult));
		TestContext.WriteLine("III - AreEqual");
		Assert.AreEqual(404, notFound.StatusCode);
	}
}