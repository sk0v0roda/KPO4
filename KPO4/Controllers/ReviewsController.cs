using KPO4.Models;
using KPO4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KPO4.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly HotelDbContext hotelDbContext;
        private readonly ReviewRepository repository;
        public ReviewsController(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
            repository = new ReviewRepository(hotelDbContext);
        }
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            return await repository.PostReview(review);
        }
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<List<Review>>> GetReviews([FromRoute] Guid id)
        {
            var reviews = await repository.GetReviews(id);
            if (reviews.Count == 0)
            {
                return Ok("Отзывов на отель нет");
            } else
            {
                return Ok(reviews);
            }
        }
    }
}
