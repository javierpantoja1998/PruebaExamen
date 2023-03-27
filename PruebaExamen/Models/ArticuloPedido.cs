using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaExamen.Models
{
	[Table("Articulos_Pedido")]
	public class ArticuloPedido
	{
		[Key]
		[Column("ID")]
		public int Id { get; set; }

		[Column("IDPEDIDO")]
		public int IdPedido { get; set; }

		[Column("NOMBRE")]
		public int Nombre { get; set; }

		[Column("DESCRIPCION")]
		public int Descripcion { get; set; }

		[Column("CANTIDAD")]
		public int Cantidad { get; set; }

	}
}
