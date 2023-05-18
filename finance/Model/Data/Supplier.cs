using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinance.Model.Data
{
	[Table("Suppliers")]
	public class Supplier : BaseModel
	{
		[DisplayName("Nome")]
		[Required]
		[MaxLength(128)]
		public string Name { get; set; } = string.Empty;		
	}
}
