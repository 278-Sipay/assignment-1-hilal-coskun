using assignment_1.Models;
using FluentValidation;
using System.Xml.Linq;
using System;

namespace assignment_1.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator() 
        {
            RuleFor(person => person.Name)
                .NotEmpty()
                .WithMessage("Staff person name is required.")
            .Length(5, 100)
                .WithMessage("Staff person name must be between 5 and 100 characters.");

            RuleFor(person => person.Lastname)
                .NotEmpty()
                .WithMessage("Staff person lastname is required.")
                .Length(5, 100)
                .WithMessage("Staff person lastname must be between 5 and 100 characters.");

            RuleFor(person => person.Phone)
                .NotEmpty()
                .WithMessage("Staff person phone number is required.")
                .Matches(@"^\d{10}$")
                .WithMessage("Staff person phone number must be a 10-digit number.");

            RuleFor(person => person.AccessLevel)
                .InclusiveBetween(1, 5)
                .WithMessage("Staff person access level must be between 1 and 5.");

        }
    }
}
