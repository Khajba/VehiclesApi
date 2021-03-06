using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MarkEng { get; set; }
        public string MarkGeo { get; set; }
        public string ModelEng { get; set; }
        public string ModelGeo { get; set; }
        public string VinCode { get; set; }
        public string VehicleNumber { get; set; }
        public string Color { get; set; }
        public IList<VehiclesPersons> VehiclesPersons { get; set; }

    }
}
