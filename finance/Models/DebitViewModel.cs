using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPFinance.Models
{
	public record DebitViewModel : BaseViewModel
	{
		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime Date { get; set; } = DateTime.Now;

		[DisplayName("Titulo")]
		public string Title { get; set; } = string.Empty;

		[DisplayName("Descrição")]
		public string? Descripton { get; set; }

		[DisplayName("Data do débito")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime DebtDay { get; set; } = DateTime.Now;

		[DisplayName("Valor")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal Value { get; set; }

		[DisplayName("Fornecedor")]
		public string? SupplierName { get; set; }
	}
}
