using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.PersonsServices.Commands.AddPerson
{
    public class AddPersonModel
    {        
        public string PersonNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
