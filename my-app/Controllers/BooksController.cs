using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_app.Entitys;
using my_app.Services;
using System.Collections.Generic;

namespace my_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(BookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _bookService.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var book = _bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            var exisingBook = _bookService.Create(book);

            if (exisingBook != null)
            {
                return Ok(book);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Book book)
        {
            var updatedBook = _bookService.Update(id, book);

            if (updatedBook == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(updatedBook);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
