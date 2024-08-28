using Microsoft.AspNetCore.Mvc;
using Restapi_PersonController.Model;
using Asp.Versioning;
using Restapi_PersonController.Business;

namespace Restapi_PersonController.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private IBooksBusiness _booksBusiness;
        public BooksController(ILogger<BooksController> logger, IBooksBusiness booksBusiness)
        {
            _logger = logger;
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpPost]
        public IActionResult PostAbc([FromBody] Books books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Create(books));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var books = _booksBusiness.FindById(id);
            if (books == null)
            {
                return NotFound("Books not found");
            }
            return Ok(_booksBusiness.FindById(id));
        }

        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Books books)
        {
            if (books == null)
            {
                return NotFound("Book not found");
            }
            return Ok(_booksBusiness.Create(books));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Books books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Update(books));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}
