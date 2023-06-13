using KPO4.Models;
using Microsoft.EntityFrameworkCore;

namespace KPO4.Repositories
{
    public class ReviewRepository
    {
        private HotelDbContext HotelDbContext { get; set; }

        public ReviewRepository(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }

        public async Task<Review> PostReview(Review review)
        {
            if (review != null)
            {
                review.Id = new Guid();
                await HotelDbContext.Reviews.AddAsync(review);
                await HotelDbContext.SaveChangesAsync();
            }
            return review;
        }
        public async Task<List<Review>> GetReviews(Guid id)
        {
            return await HotelDbContext.Reviews.Where(x => x.HotelId == id).ToListAsync();
        }
    }
}
