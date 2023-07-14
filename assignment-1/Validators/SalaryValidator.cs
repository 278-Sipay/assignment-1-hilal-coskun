using assignment_1.Models;
using FluentValidation;
using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations;

namespace assignment_1.Validators
{
    public class SalaryValidator : AbstractValidator<Person>
    {
        private readonly int _accessLevel;

        public SalaryValidator(int accessLevel)
        {
            _accessLevel = accessLevel;

            RuleFor(person => person.Salary)
                .Must(ValidateSalary)
                .WithMessage(Message);
        }

        private bool ValidateSalary(decimal salary)
        {
            switch (_accessLevel)
            {
                case 1:
                    return salary <= 10000;
                case 2:
                    return salary <= 20000;
                case 3:
                    return salary <= 30000;
                case 4:
                    return salary <= 40000;
                default:
                    return false;
            }
        }

        private string Message(Person person, decimal salary)
        {
            switch (_accessLevel)
            {
                case 1:
                    return salary > 10000 ? "Salary cannot be greater than 10000." : null;
                case 2:
                    return salary > 20000 ? "Salary cannot be greater than 20000." : null;
                case 3:
                    return salary > 30000 ? "Salary cannot be greater than 30000." : null;
                case 4:
                    return salary > 40000 ? "Salary cannot be greater than 40000." : null;
                default:
                    return "Invalid salary for staff person.";
            }
        }
    }
}
