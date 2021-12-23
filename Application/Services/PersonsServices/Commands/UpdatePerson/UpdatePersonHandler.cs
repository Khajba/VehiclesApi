using Infrastructure.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.PersonsServices.Commands.UpdatePerson
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Persons.GetById(request.Id);
            if (person == null)
            {

                return false;
            }
           person.PersonNumber = request.PersonNumber;
           person.Firstname = request.Firstname;
           person.Lastname = request.Lastname;

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
