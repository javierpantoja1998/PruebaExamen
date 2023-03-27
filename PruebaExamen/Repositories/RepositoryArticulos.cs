using PruebaExamen.Helpers;
using PruebaExamen.Models;
using System.Xml.Linq;


namespace PruebaExamen.Repositories
{
	public class RepositoryArticulos
	{
		private PathProvider helper;
		private XDocument documentArticulos;
		private string PathArticulos;

		public RepositoryArticulos(PathProvider helper)
		{
			this.helper = helper;
			this.PathArticulos = this.helper.MapPath("Articulos.xml", Folders.documents);
			documentArticulos = XDocument.Load(this.PathArticulos);
		}

		public ArticuloXml GetArticuloXPosicion(int posicion, ref int numeroarticulos)
		{
			//VOY A RECUPERAR LA COLECCION DE ESCENAS DE UNA PELICULA
			//PARA ELLO, UTILIZAMOS EL METODO ANTERIOR
			List<ArticuloXml> listaarticulos = this.GetAllArticulos();
			numeroarticulos = listaarticulos.Count;
			//VAMOS A PAGINAR DE UNO EN UNO
			ArticuloXml articulo = listaarticulos.Skip(posicion).Take(1).FirstOrDefault();
			return articulo;
		}




		public List<ArticuloXml> GetAllArticulos()
		{



			var consulta = from datos in documentArticulos.Descendants("articulo")
						   select datos;



			List<ArticuloXml> listaarticulos = new List<ArticuloXml>();
			foreach (XElement tag in consulta)
			{
				ArticuloXml articulo = new ArticuloXml();
				articulo.IdArticulo = int.Parse(tag.Attribute("idarticulo").Value);
				articulo.Nombre = tag.Element("nombre").Value;
				articulo.Descripcion = tag.Element("descripcion").Value;
				articulo.Calorias = int.Parse(tag.Element("calorias").Value);
				articulo.Proteinas = int.Parse(tag.Element("proteinas").Value);
				articulo.Hidratos = int.Parse(tag.Element("hidratos").Value);
				articulo.Glucosa = int.Parse(tag.Element("glucosa").Value);
				articulo.Cantidad = int.Parse(tag.Element("cantidad").Value);



				listaarticulos.Add(articulo);
			}
			return listaarticulos;
		}
	}
}
