using Infrastructure.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.PersonsServices.Commands.DeletePerson
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePersonHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person  = await _unitOfWork.Persons.GetById(request.Id);
            if (person == null)
            {
                return false;
            }
           _unitOfWork.Persons.Delete(person);
            await _unitOfWork.CompleteAsync();
            return true; 
        }
    }
}
