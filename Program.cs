using PrimeiraApiConsulta.Data;
using PrimeiraApiConsulta.Models;
using PrimeiraApiConsulta.Models.Interfaces;

namespace PrimeiraApiConsulta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();

            // Neste momento, o AppDbContext estar� dispon�vel para todas
            // as classes que o usarem, atrav�s de inje��o de depend�ncia.
            builder.Services.AddDbContext<AppDbContext>();



            builder.Services.AddTransient<IPessoa, Pessoa>();

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

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}