using KPO4.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace KPO4.Repositories
{
    public class BookRepository
    {
        private HotelDbContext HotelDbContext { get; set; }

        public BookRepository(HotelDbContext hotelDbContext)
        {
            HotelDbContext = hotelDbContext;
        }

        public async Task<Book> PostBook(Book book)
        {
            if (book != null)
            {
                book.Id = new Guid();
                await HotelDbContext.Books.AddAsync(book);
                await HotelDbContext.SaveChangesAsync();
            }
            return book;
        }
        public async Task<List<Book>> GetAllBooks(Book book) 
        {
            return await HotelDbContext.Books.ToListAsync();
        }
    }
}
