using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.PersonsServices.Commands.AddPerson
{
    public class AddPersonModelValidator : AbstractValidator<AddPersonModel>
    {
        public AddPersonModelValidator()
        {
            RuleFor(reg => reg.Firstname).NotEmpty();
            RuleFor(reg => reg.Lastname).NotEmpty();
            RuleFor(reg => reg.PersonNumber).NotEmpty();
        }
    }
}
