using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.VehiclesServices.Queries.GetVehiclesList
{
   public class VehiclesModel
    {
        public int Id { get; set; }
        public string MarkEng { get; set; }
        public string MarkGeo { get; set; }
        public string ModelEng { get; set; }
        public string ModelGeo { get; set; }
        public string VinCode { get; set; }
        public string VehicleNumber { get; set; }
        public string Color { get; set; }
    }
}
