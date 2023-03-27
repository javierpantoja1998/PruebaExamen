﻿using Microsoft.EntityFrameworkCore;
using PruebaExamen.Models;

namespace PruebaExamen.Data
{
	public class AppDbContext :DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Usuario> Usuarios { get; set; }

		public DbSet<Pedido> Pedidos { get; set; }

		public DbSet<ArticuloPedido> ArticulosPedido { get; set; }
	}
}
