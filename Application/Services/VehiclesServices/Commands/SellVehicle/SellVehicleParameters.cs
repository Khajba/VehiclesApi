using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.VehiclesServices.Commands.ReformVehicle
{
    public class SellVehicleParameters
    {
        public string[] SellersPersonalNumbers { get; set; }
        public string[] BuyersPersonalNumbers { get; set; }
        public string UserPersonalNumer { get; set; }
        public string VinCode { get; set; }

    }
}
