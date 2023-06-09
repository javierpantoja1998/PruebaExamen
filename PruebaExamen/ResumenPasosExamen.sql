PARA HACER LOGIN Y VISTA PARCIAL
----------
1-
DESCARGAR NUGGETS


2-
CREAR MODELOS

3-
CREAR CARPETA DATA Y EL CONTEXT

4-
CREAR CARPETA FILTERS (CUANDO HAY SEGURIDAD)
CREAR AUTHORIZEUSUARIOS

5-
IR AL PROGRAM
añadir:

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlZapatillas");
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddTransient<RepositoryArticulos>();
builder.Services.AddTransient<RepositoryPedidos>();
builder.Services.AddTransient<RepositoryUsuarios>();

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

app.UseAuthentication();

app.UseSession();
app.UseMvc(route =>
{
	route.MapRoute(
		name: "default",
		template: "{controller=Tienda}/{action=Index}/{id?}");
});


6-
CREAR CARPETA DE HELPERS
CREAR PATHPROVIDER (SE USA PARA ACCEDER A XML) y AÑADIR ADDSINGLETON en program --> builder.Services.AddSingleton<HelperPathProvider>();
CREAR CRIPTOGRAPHY (SI SE USA ENCRIPTADO)

7-
CREAR CARPETA DE REPOSITORIES

9-
AÑADIR EN EL VIEWIMPORT LOS CLAIMS

8-CREAR CONTROLLERS IMPORTANDO LOS REPOS

9-
CREAR VISTAS

10- 
CREAR VISTA PARCIAL EN EL SHARED
---------------
PAGINACION
-----------------

1. CREAR EN EL CONTOLLER EL METODO

2. CREAR LA VISTA PARA LA PAGINACION

3.CREAR UN DIV CON ID DONDE SE METE EL AJAX

4. SCRIPT DOCUMENT READY PARA CARGAR EL CONTENIDO

5.CREAR LA FUNCION DEL AJAX CON EL ENLACE

-------
CARRITO
-------

1. IMPORTAR NUGGETS: 
A) ASPNETCORE.SESSION
B) WEB.CODEGENERATION.DESIGN
C)NEWTON.JSON

2)
MODIFICAMOS EL PROGRAM

3) CREEAMOS LA CARPETA EXTENSIONS Y DENTRO EL SESSIONEXTENSION

4)VAMOS AL CONTROLLER Y CREAMOS LA FUNCION PARA GUARDAR LOS PRODUCTOS EN EL CARRITO

5)crear el repo para recoger los productos por su id producto usando el contains -> mirar algun ejemplo

5)UNA VEZ GUARDADO LOS PRODUCTOS EN EL CARRO, CREAMOS UNA VISTA PARA MOSTAR LOS OBJETOS DEL CARRITO

6)CREAMOS LA VISTA Y LE PASAMOS LOS OBJETOS DEL CARRITO CON:
@{
	List<int>carrito = Context.Session.GetObject<List<int>>("CARRITO");
}


7) HACER UN USING DEL EXTENSIONS EN VIEWIMPORTS ASI: @USING.NOMBREPROYECTO.EXTENSIONS

8)mostarr pedidos