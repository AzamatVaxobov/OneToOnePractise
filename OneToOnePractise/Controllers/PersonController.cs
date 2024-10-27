using Microsoft.AspNetCore.Mvc;
using OneToOne.DataAccess.Entities;
using OneToOne.Service.DTOs;
using OneToOne.Service.PersonService;


namespace OneToOne.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public ActionResult<long> AddPerson(PersonCreateDto personCreateDto)
        {
            var personId = _personService.AddPerson(personCreateDto);
            return CreatedAtAction(nameof(GetPersonById), new { personId }, personId);
        }

        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(long personId)
        {
            _personService.RemovePerson(personId);
            return NoContent();
        }

        [HttpGet]
        public ICollection<PersonDto> GetAllPeople()
        {
            var people = _personService.GetAll();
            return people;
        }

        [HttpGet("{personId}")]
        public ActionResult<PersonDto> GetPersonById(long personId)
        {
            var person = _personService.GetPersonById(personId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPut]
        public IActionResult UpdatePerson(PersonDto personDto)
        {
            _personService.UpdatePerson(personDto);
            return NoContent();
        }

        [HttpGet("{personId}/passport")]
        public ActionResult<PersonDto> GetPersonByIdWithPassport(long personId)
        {
            var person = _personService.GetPersonByIdWithPassport(personId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }

}
