using KPO4.Models;
using KPO4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KPO4.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly HotelDbContext hotelDbContext;
        private readonly BookRepository repository;
        public BookingsController(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
            repository = new BookRepository(hotelDbContext);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostReview(Book book)
        {
            var retBook = await repository.PostBook(book);
            if (retBook == null)
            {
                return BadRequest();
            } else
            {
                return Ok(book);
            }
        }
    }
}
