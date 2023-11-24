
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;

namespace Restaurante
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<SistemaRestauranteDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddCors();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(opcoes => opcoes.WithOrigins("http://localhost:4200") // endereço do front.
            .AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.MapControllers();

            app.Run();
        }
    } 
}