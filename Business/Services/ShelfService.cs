using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concrete.DTOs;

namespace Business.Services
{
    public class ShelfService : IShelfService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShelfService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookListItemDto>> GetBooksAsync()
        {
            var books = await unitOfWork.Books.FindManyAsync(x => x.Active, "Author", "Genre", "Publisher");
            return from book in books.ToList()
                   select new BookListItemDto
                   {
                       Id = book.Id,
                       Title = book.Title,
                       CoverImagePath = book.CoverImagePath,
                       Price = book.Price,
                       InStock = book.Stock > 0,
                       AuthorName = book.Author!.FirstName + " " + book.Author!.LastName,
                       Genre = book.Genre!.Name,
                       PublisherName = book.Publisher!.Name
                   };
        }
    }
}
