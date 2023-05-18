using ASPFinance.Core.ORM;

namespace ASPFinance.Model.Data
{
	public interface IDebit: IBase<IDebit>, IPersistentObject
	{
		DateTime DebtDay { get; set; }
		Supplier? Supplier { get; set; }
		int SupplierId { get; set; }		
	}
}