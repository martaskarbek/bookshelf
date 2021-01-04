using System.Collections.Generic;
using System.Linq;
using bookshelf.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace bookshelf.Controllers
{
    [ApiController]
    [Route("/reviews")]
    [FormatFilter]


    //[EnableCors("AllowSpecificOrigin")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private BookDBContext _context;

        public ReviewController(ILogger<ReviewController> logger, BookDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("/reviews")]
        [Produces("application/json")]
        public IQueryable Get()
        {
            this.ControllerContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin","*");
            var result = _context.Reviews.Join(
                _context.Users,
                review => review.User.Id,
                user => user.Id,
                (review, user) => new
                {
                    review,
                    user
                }).Join(
                _context.Books,
                combined => combined.review.Book.Id,
                book => book.Id,
                (combined, book) => new
                {
                    Review = combined.review,
                    User = combined.user,
                    Book = book,
                }).Join(
                _context.Authors,
                nested => nested.Book.Author.Id,
                author => author.Id,
                (nested, author) => new
                {
                    Review = nested.Review,
                    User = nested.User,
                    Book = nested.Book,
                    Author = author
                });
            return result;
        }
    }
}