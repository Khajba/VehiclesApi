using Infrastructure.Context.UnitOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.PersonsServices.Queries.GetPersonById
{
    public class PersonByNumberHandler : IRequestHandler<PersonByNumberQuery, PersonByNumberModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonByNumberHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PersonByNumberModel> Handle(PersonByNumberQuery request,
            CancellationToken cancellationToken)
        {

            var model = await _unitOfWork.Persons.GetByPersonNumber(request.PersonalNumber);
            if (model == null)
            {
                throw new Exception("მომხმარებელი არ არსებობს");
            }

            var result = new PersonByNumberModel
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

