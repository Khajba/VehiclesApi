using Infrastructure.Entities;
using MediatR;

namespace Application.Services.VehiclesServices.Queries.GetVehiclebyId
{
    public class VehiclebyVinCodeQuery : IRequest<Vehicles>
    {
        public string VinCode { get; set; }
    }
}
