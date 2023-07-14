using assignment_1.Models;
using assignment_1.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly List<Person> _personList;

        public PersonController(List<Person> personList)
        {
            _personList = personList;
        }

        [HttpGet]
        public List<Person> Get()
        {
            return _personList.ToList();
        }


        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            PersonValidator validator = new PersonValidator();
            var validationResult = validator.Validate(person);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _personList.Add(person);

            return Ok(person);
        }
    }
}
