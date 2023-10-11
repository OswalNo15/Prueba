using Microsoft.EntityFrameworkCore;
using PruebaInfodesingBackend.DAL.Context;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Cadena de conexion de mi dbContext
builder.Services.AddDbContext<PruebaInfoDesignContext>(opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQllocal")) );
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
