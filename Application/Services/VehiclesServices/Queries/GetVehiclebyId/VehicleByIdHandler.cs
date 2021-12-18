using Infrastructure.Context.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.VehiclesServices.Queries.GetVehiclebyId
{
    public class VehicleByIdHandler : IRequestHandler<VehicleByIdQuery, VehicleModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;



        public async Task<VehicleModel> Handle(VehicleByIdQuery request,
            CancellationToken cancellationToken)
        {

                var model = await _unitOfWork.Vehicles.GetById(request.Id);
                if(model == null)
                {
                    throw new Exception();
                }

                var result = new VehicleModel
                {
                    Id = model.Id,
                    Color = model.Color,
                    MarkEng = model.MarkEng,
                    ModelEng = model.ModelEng,
                    MarkGeo = model.MarkGeo,
                    ModelGeo = model.ModelGeo,
                    VehicleNumber = model.VehicleNumber,
                    VinCode = model.VinCode
                };
                return result;
            }
        }
    }


