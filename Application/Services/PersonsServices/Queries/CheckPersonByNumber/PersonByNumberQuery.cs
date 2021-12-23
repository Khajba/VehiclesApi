using MediatR;

namespace Application.Services.PersonsServices.Queries.GetPersonById
{
    public class PersonByNumberQuery : IRequest<PersonByNumberModel>
    {
        public string PersonalNumber { get; set; }
    }
}
