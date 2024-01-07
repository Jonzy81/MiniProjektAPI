using MiniProjektAPI.Data;
using MiniProjektAPI.Model.DTO;
using MiniProjektAPI.Model.ViewModel;
using System.Net;


namespace MiniProjektAPI.Handlers
{
    public class PersonInformationHandler
    {
        public static IResult AddNewUser(ApplicationContext context, AddPersonDto person)
        {
            context.Persons.Add(new Model.Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
            });
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }
        public static IResult ListAllMembers(ApplicationContext context)
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
        }
    }
}
