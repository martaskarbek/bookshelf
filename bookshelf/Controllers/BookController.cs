using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace bookshelf.Controllers
{
    [ApiController]
    [Route("/books")]
    [FormatFilter]

    //[EnableCors(origins: "", headers: "*", methods: "*")]    
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }
        
    }
}