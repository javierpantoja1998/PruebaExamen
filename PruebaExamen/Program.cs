using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PruebaExamen.Data;
using PruebaExamen.Helpers;
using PruebaExamen.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("SqlZapatillas");
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddTransient<RepositoryArticulos>();
builder.Services.AddTransient<RepositoryPedidos>();
builder.Services.AddTransient<RepositoryUsuarios>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


//SEGURIDAD
builder.Services.AddAuthentication(options =>
{
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(
	CookieAuthenticationDefaults.AuthenticationScheme,
	config =>
	{
		config.AccessDeniedPath = "/Managed/ErrorAcceso";
	});


//FUNCIONES DE CACHE Y SESSION
builder.Services.AddSession();
builder.Services.AddControllersWithViews(options =>
options.EnableEndpointRouting = false)
	.AddSessionStateTempDataProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseMvc(route =>
{
	route.MapRoute(
		name: "default",
		template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
