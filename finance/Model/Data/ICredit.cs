using ASPFinance.Core.ORM;

namespace ASPFinance.Model.Data
{
	public interface ICredit: IBase<ICredit>, IPersistentObject
	{		
		DateTime CreditDay { get; set; }
		Customer? Customer { get; set; }
		int CustomerId { get; set; }					
	}
}