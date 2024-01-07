using Microsoft.EntityFrameworkCore;
using MiniProjektAPI.Data;
using MiniProjektAPI.Model;
using MiniProjektAPI.Model.DTO;
using System.Net;

namespace MiniProjektAPI.Handlers
{
    public class InterestHandler
    {
        public static IResult AddInterest(ApplicationContext context, int id, AddInterestDto interestDto)
        {
            var person = context.Persons
                .Include(p => p.Interests)
                .FirstOrDefault(p => p.Id == id);

            if(person == null)
            {
                return Results.NotFound("Person not found");
            }

            var newInterest = new Interest
            {
                Interests = interestDto.InterestName,
                InterestDescription = interestDto.InterestDescription,
            };
            person.Interests.Add(newInterest);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
