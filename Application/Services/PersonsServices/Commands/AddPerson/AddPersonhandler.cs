using Infrastructure.Context.UnitOfWork;
using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.PersonsServices.Commands.AddPerson
{
    class AddPersonhandler : IRequestHandler<AddPersonCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddPersonhandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var newPerson = new Persons
            {
                PersonNumber = request.PersonNumber,
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };

            var isAdded = await _unitOfWork.Persons.Add(newPerson);
            await _unitOfWork.CompleteAsync();
            return isAdded;       

        }


    }
}
