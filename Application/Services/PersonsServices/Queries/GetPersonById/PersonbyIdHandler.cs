using Infrastructure.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.PersonsServices.Queries.GetPersonById
{
    public class PersonbyIdHandler : IRequestHandler<PersonByIdQuery, PersonModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonbyIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PersonModel> Handle(PersonByIdQuery request,
            CancellationToken cancellationToken)
        {

            var model = await _unitOfWork.Persons.GetById(request.Id);
            if (model == null)
            {
                throw new Exception();
            }

            var result = new PersonModel
            {
                Id = model.Id,
                PersonNumber = model.PersonNumber,
                Firstname = model.Firstname,
                Lastname = model.Lastname
               
            };
            return result;
        }
    }
}

