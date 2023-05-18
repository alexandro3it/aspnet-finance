using ASPFinance.Application.Services;
using ASPFinance.Model.Data;
using ASPFinance.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPFinance.Controllers
{
	public class CreditsController : ControllerBase<ICreditsApplicationServices, Credit>
	{
		public CreditsController(IMapper mapper, ICreditsApplicationServices context)
			: base(mapper, context)
		{
		}

		public override async Task<IActionResult> Index() => View(_mapper.Map<List<CreditViewModel>>(await _context.GetAll()));

		public override IActionResult Create()
		{
			AddViewBags();
			return base.Create();
		}

		private void AddViewBags()
		{
			ViewBag.Customers = _context.GetAllCustomers().Result
				.Select(model => new SelectListItem() { Text = model.Name, Value = model.Id.ToString() })
				.ToList();
		}

		public override async Task<IActionResult> Create(Credit model)
		{
			if (ModelState.IsValid)
			{
				await _context.CreateAsync(model.Go());
				return RedirectToAction(nameof(Index));
			}

			AddViewBags();
			return View(model);
		}

		public override async Task<IActionResult> Edit(int? id)
		{
			if (id is null)
			{
				return NotFound();
			}

			ICredit? model;
			if ((model = await _context.GetAsync(id)) is not null)
			{
				AddViewBags();
				return View(model);
			}

			return NotFound();
		}

		public override async Task<IActionResult> Edit(int id, Credit model)
		{
			if (id != model.Id || (await _context.GetAsync(id)) is null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _context.UpdateAsync(model.Go());
				}
				catch (DbUpdateConcurrencyException)
				{
					if (await _context.GetAsync(id) is null)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		public override async Task<IActionResult> Delete(int? id)
		{
			if (id is null)
			{
				return NotFound();
			}

			ICredit? model;
			if ((model = await _context.GetAsync(id)) is null)
			{
				return NotFound();
			}

			return View(_mapper.Map<CreditViewModel>(model));
		}

		public override async Task<IActionResult> DeleteConfirmed(int id)
		{
			ICredit? model;
			if ((model = await _context.GetAsync(id)) is null)
			{
				return NotFound();
			}

			await _context.DeleteAsync(model);
			return RedirectToAction(nameof(Index));
		}
	}
}
