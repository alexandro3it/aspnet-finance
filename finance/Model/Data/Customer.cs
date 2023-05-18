using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinance.Model.Data
{
	[Table("Customers")]
	public class Customer : BaseModel
	{
		[DisplayName("Nome")]
		[Required]
		[MaxLength(128)]
		public string Name { get; set; } = string.Empty;		
	}
}
