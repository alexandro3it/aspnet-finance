using ASPFinance.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPFinance.Controllers
{
	public abstract class ControllerBase<T, Model> : Controller
		where T : class
		where Model : BaseModel, new()
	{
		protected readonly T _context;
		protected readonly IMapper _mapper;

		private ControllerBase(IMapper mapper) => _mapper = mapper;
		protected ControllerBase(IMapper mapper, T context)
			: this(mapper) => _context = context;

		public abstract Task<IActionResult> Index();
		public virtual IActionResult Create() => View(new Model());

		[HttpPost]
		[ValidateAntiForgeryToken]
		public abstract Task<IActionResult> Create(Model model);

		public abstract Task<IActionResult> Edit(int? id);

		[HttpPost]
		[ValidateAntiForgeryToken]
		public abstract Task<IActionResult> Edit(int id, Model model);

		public abstract Task<IActionResult> Delete(int? id);

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public abstract Task<IActionResult> DeleteConfirmed(int id);
	}
}
