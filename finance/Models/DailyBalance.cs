using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPFinance.Models
{
	public record DailyBalanceViewModel
	{
		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime Date { get; init; }

		[DisplayName("Saldo anterior")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal PreviousValue { get; init; }

		[DisplayName("Total de entrada(s)")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal TotalInput { get; init; }

		[DisplayName("Total de saída(s)")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal TotalOutput { get; init; }

		[DisplayName("Saldo final")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		public decimal FinalBalance { get; init; }		
	}
}
