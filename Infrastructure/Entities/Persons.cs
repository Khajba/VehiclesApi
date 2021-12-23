using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
    public class Persons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PersonNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IList<VehiclesPersons> VehiclesPersons { get; set; }
    }
}
