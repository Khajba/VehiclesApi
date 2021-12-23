using Infrastructure.Context.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.VehiclesServices.Queries.GetVehiclesList
{
    public class VehiclesListHandler : IRequestHandler<VehiclesListQuery, IEnumerable<VehiclesModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesListHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;



        public async Task<IEnumerable<VehiclesModel>> Handle(VehiclesListQuery request,
            CancellationToken cancellationToken)
        {

            var model = await _unitOfWork.Vehicles.All();
            
            var result = model.ToList().Select(e => new VehiclesModel
            {
                Id = e.Id,
                Color = e.Color,
                MarkEng = e.MarkEng,
                ModelEng = e.ModelEng,
                MarkGeo = e.MarkGeo,
                ModelGeo = e.ModelGeo,
                VehicleNumber = e.VehicleNumber,
                VinCode = e.VinCode
            });
            return result;
        }
    }
}

