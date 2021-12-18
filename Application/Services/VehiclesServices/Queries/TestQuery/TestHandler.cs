using Infrastructure.Context.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.VehiclesServices.Queries.GetVehiclesList
{
    public class TestHandler : IRequestHandler<TestQuery, string>
    {

        public async Task<string> Handle(TestQuery request,
            CancellationToken cancellationToken)
        {

            return ("test");
        }
    }
}

