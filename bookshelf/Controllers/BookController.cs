using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookshelf.Controllers
{
    [ApiController]
    [Route("/books")]
    [FormatFilter]
    
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }
        
    }
}