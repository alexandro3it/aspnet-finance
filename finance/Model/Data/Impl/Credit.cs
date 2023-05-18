using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinance.Model.Data
{

	[Table("Credits")]
	public class Credit : BaseModel, ICredit
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

		[DisplayName("Data do crédito")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime CreditDay { get; set; } = DateTime.Today;

		[DisplayName("Valor")]
		[DisplayFormat(DataFormatString = "{0:C}")]
		[Required]
		[DataType(DataType.Currency)]
		[Precision(18, 2)]
		public decimal Value { get; set; }

		[DisplayName("Cliente")]
		[Required]
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
		public Customer? Customer { get; set; }

		public ICredit Go()
		{
			Value = Math.Round(Value / 100, 2);
			return this;
		}
	}
}
