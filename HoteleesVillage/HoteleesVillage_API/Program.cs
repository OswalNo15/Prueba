using System.Text.Json.Serialization;
using HotelesVillage.Aplicaciones.Interfaces;
using HotelesVillage.Aplicaciones.Servicio;
using HotelesVillage.Dominio.Interfaces;
using HotelesVillage.Dominio.Modelos;
using HotelesVillage.Dominio.Repositorios;
using HotelesVillages.Infraestructura.Datos.DataContext;
using HotelesVillages.Infraestructura.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Cadena de conexion con mi dbContext

builder.Services.AddDbContext<HotelesContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenalSQLLocalHost")));

#endregion

#region inyeccion de dependencias 
builder.Services.AddScoped<IRepositorioHoteles<Hotel>, HotelesRepositorio>();
builder.Services.AddScoped<IRepositorioHabitaciones<Habitacione>, HabitacionesRepositorio>();

builder.Services.AddScoped<IServicioHoteles, HotelesServicio>();

builder.Services.AddScoped<IServicioHabitaciones, HabitacionesServicio>();
#endregion


#region configuracion para quitar la serializacion de json de referencias ciclica
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
#endregion


#region configuracion para activacion de CORS
var MyRulesCors = "HotelesNetCoreRules";
builder.Services.AddCors(opt => opt.AddPolicy(name: MyRulesCors, builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region ejecucion del cors
app.UseCors(MyRulesCors);
#endregion

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
