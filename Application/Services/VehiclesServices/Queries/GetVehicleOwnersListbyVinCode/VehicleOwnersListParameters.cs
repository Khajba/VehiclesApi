using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.VehiclesServices.Queries.GetVehicleOwnersListbyVinCode
{
    public class VehicleOwnersListParameters
    {
        public string VinCode { get; set; }
        public string OrderString { get; set; }
    }
}
