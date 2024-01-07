using Microsoft.EntityFrameworkCore;
using MiniProjektAPI.Data;
using MiniProjektAPI.Model;
using MiniProjektAPI.Model.DTO;
using System.Net;

namespace MiniProjektAPI.Handlers
{
    public class LinkHandler
    {
        public static IResult AddNewLink(ApplicationContext context, int personId, int interestId, AddLinkDto addLink)
        {
            var person = context.Persons
                .Include(p => p.Interests)
                .FirstOrDefault(p => p.Id == personId);
            
            if (person == null)
            {
                return Results.NotFound("Person not found.");
            }

            if (!person.Interests.Any(i => i.Id == interestId))
            {
                return Results.NotFound("Interest not associated with person.");
            }

            var interest = context.Interests
                .FirstOrDefault(i => i.Id== interestId);
            if (interest == null)
            {
                return Results.NotFound("Interest not found");
            }
            if (string.IsNullOrEmpty(addLink.Link))
            {
                return Results.Problem(title: "Missing data", detail: "no link was provided", statusCode: 400);
            }
            var newLink = new InterestLinks
            {
                WebLinks = addLink.Link,
                Person = person,
                Interest = interest,
            };
            context.InterestLinks.Add(newLink);
            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
