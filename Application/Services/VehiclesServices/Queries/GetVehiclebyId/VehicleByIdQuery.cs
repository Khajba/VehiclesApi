using MediatR;

namespace Application.Services.VehiclesServices.Queries.GetVehiclebyId
{
    public class VehicleByIdQuery : IRequest<VehicleModel>
    {
        public int Id { get; set; }
    }
}
