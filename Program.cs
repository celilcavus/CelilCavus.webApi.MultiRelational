using System.Reflection;
using CelilCavus.Interface;
using CelilCavus.Models.Contexts;
using CelilCavus.Repository;
using CelilCavus.Services;
using CelilCavus.UnitOfWork;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped<IUow,Uow>();
        builder.Services.AddScoped<DbContext,MultiContext>();
        // builder.Services.AddScoped<IRepository<>,CustomerServices>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
    }
}