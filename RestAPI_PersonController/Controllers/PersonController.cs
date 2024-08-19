using Microsoft.AspNetCore.Mvc;
using Restapi_PersonController.Model;
using Restapi_PersonController.Services;

namespace My_first_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpPost]
        public IActionResult PostAbc([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person  = _personService.FindById(id);
            if (person == null) 
            { 
                return NotFound("Person not found");
            }
            return Ok(_personService.FindById(id));
        }

        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound("Person not found");
            }
            return Ok(_personService.Create(person));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound("Person not found");
            }
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
