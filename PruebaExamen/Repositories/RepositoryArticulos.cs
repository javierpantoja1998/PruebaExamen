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

		public List<ArticuloXml>
	}
}
