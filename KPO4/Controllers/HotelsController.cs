using KPO4.Models;
using KPO4.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KPO4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext hotelDbContext;
        private readonly HotelRepository repository;

        public HotelsController(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
            repository = new HotelRepository(hotelDbContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetItems()
        {
            return await repository.GetAll();
        }
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Hotel>> GetItem([FromRoute] Guid id)
        {
            var hotel = await repository.Get(id);
            if (hotel == null)
            {
                return BadRequest("Такого отеля нет!");
            } else
            {
                return Ok(hotel);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateItem(Hotel hotel)
        {
            await repository.Post(hotel);
            return hotel;
        }
    }
}
