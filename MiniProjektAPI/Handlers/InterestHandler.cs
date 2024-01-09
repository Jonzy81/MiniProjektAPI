using Microsoft.EntityFrameworkCore;
using MiniProjektAPI.Data;
using MiniProjektAPI.Model;
using MiniProjektAPI.Model.DTO;
using MiniProjektAPI.Model.ViewModel;
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

        public static IResult AssignInterestToMember(ApplicationContext context, int personId, int interestId)
        {
            var person = context.Persons    //Var är ett hjälpvertyg som säger fyll i när vi kompilerar, ett alternativ hade varit att skriva Person istället
                .Include(p => p.Interests)
                .SingleOrDefault(p => p.Id == personId);
            var interest = context.Interests.Find(interestId);
            //Checks if person and interest is in database
            if(person == null)
            {
                return Results.NotFound($"Person with ID {personId} not found");
            }

            if (interest == null)
            {
                return Results.NotFound($"Interest with Id{interestId} not found");
            }

            if (person.Interests.Any(i => i.Id == interestId))  //Addin conditions
            {
                return Results.Conflict($"Person already has the interest with ID {interestId}");
            }

            person.Interests.Add(interest);
            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }
        public static IResult ShowMemberInterest(ApplicationContext context, int id)
        {
            var person = context.Persons
                .Include(p => p.Interests)
                .FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return Results.NotFound("Person not found");
            }
            var result = person.Interests
                .Select(r => new InterestViewModel
                {
                    Interests = r.Interests,
                    InterestDescription = r.InterestDescription,
                }).ToArray();
            return Results.Json(result);

            /* public static IResult ListAllMembers(ApplicationContext context)
        {
            PersonListViewModel[] result =
                context.Persons
                .Select(b => new PersonListViewModel()
                {
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    PhoneNumber = b.PhoneNumber,
                }).ToArray();
            return Results.Json(result);
        }*/
        }
    }
}
