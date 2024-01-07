using Microsoft.EntityFrameworkCore;
using MiniProjektAPI.Data;
using MiniProjektAPI.Handlers;

namespace MiniProjektAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            //Add Users
            app.MapPost("/User", PersonInformationHandler.AddNewUser);
            //Add Interest
            app.MapPost("/person/{id}/interests", InterestHandler.AddInterest);

            app.Run();
        }
    }
}
