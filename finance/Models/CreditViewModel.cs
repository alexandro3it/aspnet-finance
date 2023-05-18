using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPFinance.Models
{
	public record CreditViewModel : BaseViewModel
	{		
		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime Date { get; init; } = DateTime.Now;

		[DisplayName("Titulo")]
		public string Title { get; init; } = string.Empty;

		[DisplayName("Descrição")]
		public string? Descripton { get; init; }

		[DisplayName("Data do crédito")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime CreditDay { get; init; } = DateTime.Now;

		[DisplayName("Valor")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal Value { get; init; }

		[DisplayName("Cliente")]
		public string? CustomerName { get; init; }
	}
}
