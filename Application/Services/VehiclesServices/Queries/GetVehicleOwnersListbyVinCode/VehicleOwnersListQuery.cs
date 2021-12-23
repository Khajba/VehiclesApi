using Infrastructure.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Services.VehiclesServices.Queries.GetVehiclebyId
{
    public class VehicleOwnersListQuery : IRequest<IEnumerable<VehicleOwnersListModel>>
    {
        public string VinCode { get; set; }
        public string OrderString { get; set; }
    }
}
