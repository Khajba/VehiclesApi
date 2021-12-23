using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
    public class VehiclesPersons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public int VehicleId { get; set; }
        public string OwnerType { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public bool IsActive { get; set; }
        public int PersonId { get; set; }
        public Persons Persons { get; set; }
        public Vehicles Vehicles { get; set; }       
    }
}
