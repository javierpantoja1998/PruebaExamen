using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaExamen.Models
{
	[Table("Pedidos")]
	public class Pedido
	{
		[Key]
		[Column("ID")]
		public int Id { get; set; }

		[Column("ID")]
		public int IdUsuario { get; set; }

		[Column("FECHA_PEDIDO")]
		public int FechaPedido { get; set; }

	}
}
