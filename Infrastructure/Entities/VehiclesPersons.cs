using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class VehiclesPersons
    {
        public int Id { get; set; }        
        public int VehicleId { get; set; }
        public string OwnerType { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public bool IsActive { get; set; }
        public Vehicles Vehicles { get; set; } 
        
    }
}
