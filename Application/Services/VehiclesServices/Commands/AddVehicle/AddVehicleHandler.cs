using Infrastructure.Context.UnitOfWork;
using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.VehiclesServices.Commands.AddVehicle
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddVehicleHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            var newVewhicle = new Vehicles
            {
                MarkEng = request.MarkEng,
                MarkGeo = request.MarkGeo,
                ModelEng = request.ModelEng,
                ModelGeo = request.ModelGeo,
                VinCode = request.VinCode,
                VehicleNumber = request.VehicleNumber,
                Color = request.Color
            };

            var IsAdded = await _unitOfWork.Vehicles.Add(newVewhicle);
            await _unitOfWork.CompleteAsync();
            return IsAdded;
        }
    }
}
