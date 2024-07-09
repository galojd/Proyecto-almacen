using Aplicacion.Clientes;
using Aplicacion.Inventarios;
using Aplicacion.Productos;
using Dominio.entities;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Persistencia;
using webAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar servicios de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});



builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Consulta_producto_stock>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//para crear los usuarios, esta es la configuracion que necesita el core identity para trabajar con los api
var build = builder.Services.AddIdentityCore<Usuario>();
var identitybuilder = new IdentityBuilder(build.UserType, build.Services);
identitybuilder.AddEntityFrameworkStores<AlmacenOnlineContext>();
identitybuilder.AddSignInManager<SignInManager<Usuario>>();
builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

builder.Services.AddAutoMapper(typeof(ConsultaInventario.Manejador));
//esto lo agrego para la coneccion, es decir se inyecta para poder mapear con el entity
builder.Services.AddDbContext<AlmacenOnlineContext>(options =>
//{ options.UseSqlServer(builder.Configuration.GetConnectionString("AlmacenConecction")); });
                options
                .UseMySql(
                    builder.Configuration.GetConnectionString("AlmacenConecction"),
                    new MySqlServerVersion(new Version(10, 5, 23))
                )
            );

//se crea un servicio para imediador(este es para el que tiene la capa de aplicacion)
builder.Services.AddMediatR(typeof(Consulta.Manejador).Assembly);
//builder.Services.AddMediatR(typeof(IStartup).Assembly);

builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "Servicios para mantenimiento de Almacen",
        Version = "v1"
    });
    //le indico que trabaje con el nombre completo de las clases que me permiten mapear el nombre del cliente
    c.CustomSchemaIds(c => c.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//esto se agrega para que conecte, debes agregarlo despues del servicio
using(var ambiente = app.Services.CreateScope()){
    var services = ambiente.ServiceProvider;
    try{
        var userManager = services.GetRequiredService<UserManager<Usuario>>();
        var context = services.GetRequiredService<AlmacenOnlineContext>();
        context.Database.Migrate();
        DataPrueba.InsertarData(context, userManager).Wait();
    }catch (Exception e){
        var logging = services.GetRequiredService<ILogger<Program>>();
        logging.LogError(e, "Ocurrio un error de migracion");
    }
}

//app.UseHttpsRedirection();

// Usar CORS
app.UseCors("AllowAnyOrigin");

app.UseMiddleware<ManejadorErrorMiddleware>();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI( c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Almacen Online v1");
});

app.MapControllers();

app.Run();
