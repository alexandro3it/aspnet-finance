using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinance.Model.Data
{
	[Table("Debits")]
	public sealed class Debit : BaseModel, IDebit
	{
		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; } = DateTime.Now;

		[DisplayName("Titulo")]
		[Required]
		[MaxLength(128)]
		public string Title { get; set; } = string.Empty;

		[DisplayName("Descrição")]
		[MaxLength(512)]
		public string? Descripton { get; set; }

		[DisplayName("Data do débito")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime DebtDay { get; set; } = DateTime.Today;

		[DisplayName("Valor")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		[Required]
		[DataType(DataType.Currency)]
		[Precision(18, 2)]
		public decimal Value { get; set; }

		[DisplayName("Fornecedor")]
		[Required]
		[ForeignKey("Supplier")]
		public int SupplierId { get; set; }
		public Supplier? Supplier { get; set; }

		public IDebit Go()
		{
			Value = Math.Round(Value / 100, 2);
			return this;
		}
	}
}
