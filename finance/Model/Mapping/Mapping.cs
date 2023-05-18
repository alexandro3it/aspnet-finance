using ASPFinance.Model.Data;
using ASPFinance.Models;
using AutoMapper;

namespace ASPFinance.Model.Mapping
{
	public class Mapping
	{
		public static MapperConfiguration RegisterMaps() => new(cfg =>
		{
			cfg
				.CreateMap<Debit, DebitViewModel>()
				.ForMember(model => model.SupplierName, model => model.MapFrom(mf => mf.Supplier.Name));

			cfg
				.CreateMap<Credit, CreditViewModel>()
				.ForMember(model => model.CustomerName, model => model.MapFrom(mf => mf.Customer.Name));
		});
	}
}
