using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.PersonsServices.Queries.GetPersonById
{
    public class PersonByNumberModel
    {
        public int Id { get; set; }
        public string PersonNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
