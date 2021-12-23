using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.PersonsServices.Commands.UpdatePerson
{
    public class UpdatePersonModel
    {
        public int Id { get; set; }
        public string PersonNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
