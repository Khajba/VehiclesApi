using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.VehiclesServices.Queries.GetVehiclesList
{
    public class VehiclesListQuery : IRequest<IEnumerable<VehiclesModel>>
    {
    }
}
