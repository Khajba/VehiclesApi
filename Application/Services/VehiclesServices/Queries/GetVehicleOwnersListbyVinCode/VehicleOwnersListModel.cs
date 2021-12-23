using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.VehiclesServices.Queries.GetVehiclebyId
{
    public class VehicleOwnersListModel
    {        
        public string PersonNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? CreateDateTime { get; set; }
        
    }
}
