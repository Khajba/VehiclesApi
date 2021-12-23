using Application.Services.VehiclesServices.Queries.GetVehicleOwnersListbyVinCode;
using Infrastructure.Context.UnitOfWork;
using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.VehiclesServices.Queries.GetVehiclebyId
{
    public class VehicleOwnersListHandler : IRequestHandler<VehicleOwnersListQuery, IEnumerable<VehicleOwnersListModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleOwnersListHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;      

        public async Task<IEnumerable<VehicleOwnersListModel>> Handle(VehicleOwnersListQuery request, CancellationToken cancellationToken)
        {

            var model = await _unitOfWork.Vehicles.GetFullInfoByVinCode(request.VinCode);
            if (model == null)
            {
                throw new Exception("სატრანსპორტო საშუალება ვერ მოიძებნა");
            }


            List<VehicleOwnersListModel> OwnersList = new List<VehicleOwnersListModel>();
            

            foreach (var item in model.VehiclesPersons)
            {
                var owner = new VehicleOwnersListModel();
                owner.Firstname = item.Persons.Firstname;
                owner.Lastname = item.Persons.Lastname;
                owner.PersonNumber = item.Persons.PersonNumber;
                owner.CreateDateTime = item.CreateDateTime;
                
                
                
                OwnersList.Add(owner);
            }
            if (request.OrderString == "Asc")
            {
                OwnersList.OrderBy(e => e.CreateDateTime); 
            }

            if (request.OrderString == "Desc")
            {
                OwnersList.OrderByDescending(e => e.CreateDateTime); 
            }

            return OwnersList;           
            
        }
    }
    }


