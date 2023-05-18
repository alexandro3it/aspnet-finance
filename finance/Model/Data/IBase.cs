using ASPFinance.Core.Domains;

namespace ASPFinance.Model.Data
{
	public interface IBase<T>: IEntity, IAgregateRoot
	{
		DateTime Date { get; set; }
		string Title { get; set; }
		string? Descripton { get; set; }
		decimal Value { get; set; }

		T Go();
	}
}