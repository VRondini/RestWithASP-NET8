using Microsoft.AspNetCore.Mvc;
using Restapi_PersonController.Model;
using Asp.Versioning;
using Restapi_PersonController.Business;

namespace Restapi_PersonController.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpPost]
        public IActionResult PostAbc([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person  = _personBusiness.FindById(id);
            if (person == null) 
            { 
                return NotFound("Person not found");
            }
            return Ok(_personBusiness.FindById(id));
        }

        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound("Person not found");
            }
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }
}
