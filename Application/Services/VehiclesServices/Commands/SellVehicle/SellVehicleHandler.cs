using Infrastructure.Context.UnitOfWork;
using Infrastructure.Entities;
using Infrastructure.Helpers.OwnerTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.VehiclesServices.Commands.ReformVehicle
{
    public class SellVehicleHandler : IRequestHandler<SellVehicleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellVehicleHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Handle(SellVehicleCommand request, CancellationToken cancellationToken)
        {
             var vehicle =await _unitOfWork.Vehicles.GetByVinCode(request.VinCode);
            if(vehicle == null)
            {
                return await  Task.FromResult(false);
            }

            // get sellers list
            List<int> sellersList = new List<int>();
            foreach (var sellerNumber in request.SellersPersonalNumbers) {
                var seller = await _unitOfWork.Persons.GetByPersonNumber(sellerNumber);
                sellersList.Add(seller.Id);
            }


            // get buyes list
            List<int> buyersList = new List<int>();
            foreach (var buyerNumber in request.BuyersPersonalNumbers)
            {
                var seller = await _unitOfWork.Persons.GetByPersonNumber(buyerNumber);
                buyersList.Add(seller.Id);
            }


            var VehicleSellers = await _unitOfWork.VehiclesPersons.Find(e=>e.VehicleId == vehicle.Id);

            // make sellers inactive
            foreach (var item in VehicleSellers)
            {
                item.IsActive = false;
            }


            // make buyers and user active
            foreach (var buyerId in buyersList)
            {
                var newBuyer = new VehiclesPersons
                {
                    CreateDateTime = DateTime.Now,
                    IsActive = true,
                    OwnerType = OwnerTypes.Owner,
                    VehicleId = vehicle.Id,
                    PersonId = buyerId
                };
                await _unitOfWork.VehiclesPersons.Add(newBuyer);
            }

            if (!string.IsNullOrEmpty(request.UserPersonalNumer)) 
            {
                var user = await _unitOfWork.Persons.GetByPersonNumber(request.UserPersonalNumer);

                var newVehicleUser = new VehiclesPersons
                {
                    CreateDateTime = DateTime.Now,
                    IsActive = true,
                    OwnerType = OwnerTypes.User,
                    VehicleId = user.Id
                };
                await _unitOfWork.VehiclesPersons.Add(newVehicleUser);
            }

            await _unitOfWork.CompleteAsync();
            return await Task.FromResult(true);

        }
    }
}
