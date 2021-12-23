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
    public class VehiclebyVinCodeHandler : IRequestHandler<VehiclebyVinCodeQuery, Vehicles>
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiclebyVinCodeHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;



        public async Task<Vehicles> Handle(VehiclebyVinCodeQuery request,
            CancellationToken cancellationToken)
        {

                var model = await _unitOfWork.Vehicles.GetFullInfoByVinCode(request.VinCode);
                if(model == null)
                {
                    throw new Exception();
                }
          
                return model;
            }
        }
    }


