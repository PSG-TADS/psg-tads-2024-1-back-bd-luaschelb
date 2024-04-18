using Microsoft.EntityFrameworkCore;
using LocadoraVeiculos.Models;

namespace LocadoraVeiculos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LocadoraContext>();

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();


            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}
