using KPO4.Models;
using Microsoft.EntityFrameworkCore;

namespace KPO4.Repositories
{
    public class HotelRepository
    {
        private HotelDbContext HotelDbContext { get; set; }

        public HotelRepository(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }

        public async Task<List<Hotel>> GetAll()
        {
            return await HotelDbContext.Hotels.ToListAsync();
        }

        public async Task<Hotel> Get(Guid id)
        {
            return await HotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Hotel> Post(Hotel hotel)
        {
            if (hotel != null)
            {
                hotel.Id = new Guid();
                await HotelDbContext.Hotels.AddAsync(hotel);
                await HotelDbContext.SaveChangesAsync();
            }
            return hotel;
        }
    }
}
