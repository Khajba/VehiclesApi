using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.PersonsServices.Queries.GetPersonById
{
    public class PersonByIdQuery : IRequest<PersonModel>
    {
        public int Id { get; set; }
    }
}
