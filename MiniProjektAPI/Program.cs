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
            //Users
            app.MapPost("/User", PersonInformationHandler.AddNewUser);  //Doesnt show the id, i can change it in dto later
            app.MapGet("/User/members", PersonInformationHandler.ListAllMembers);

            //Interest
            app.MapPost("/user/{id}/interests", InterestHandler.AddInterest);
            app.MapPost("/user/{personId}/interests/{interestId}", InterestHandler.AssignInterestToMember);
            app.MapGet("/user/{id}", InterestHandler.ShowMemberInterest);
            
            //link 
            app.MapPost("/user/{personId}/interest/{interestId}/links",LinkHandler.AddNewLink);
            app.MapGet("user/{id}/links", LinkHandler.ShowLinksForMember);

            app.Run();
        }
    }
}
