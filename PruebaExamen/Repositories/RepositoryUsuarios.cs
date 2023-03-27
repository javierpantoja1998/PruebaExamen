
using PruebaExamen.Data;
using PruebaExamen.Models;

namespace PruebaExamen.Repositories
{
	public class RepositoryUsuarios
	{
		private AppDbContext context;

		public RepositoryUsuarios(AppDbContext context)
		{
			this.context = context;
		}

		//Buscar usuario por nombre y contraseña
		public Usuario GetUserByNamePass(string nombre, string contrasenha)
		{
			return this.context.Usuarios.Where(x => x.Nombre == nombre && x.Contrasenha == contrasenha).AsEnumerable().FirstOrDefault();
		}


	}
}
