using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.PersonsServices.Commands.DeletePerson
{
    public class DeletePersonCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
