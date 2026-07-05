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

        public Task<IEnumerable<BookListItemDto>> FilterBooksAsync(FilterDto filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            var authors = await unitOfWork.Authors.FindManyAsync();
            return from author in authors.ToList()
                   select new AuthorDto
                   {
                       Id = author.Id,
                       FullName = author.FirstName + " " + author.LastName,
                       Biography = author.Biography,
                       Picture = author.Picture,
                   };
        }

        public async Task<BookDetailDto?> GetBookDetailByIdAsync(int id)
        {
            var books = await unitOfWork.Books.FindManyAsync(x => x.Id == id, "Author", "Genre", "Publisher");

            var book = books.FirstOrDefault();

            if (book != null)
            {
                return new BookDetailDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    CoverImagePath = book.CoverImagePath,
                    Price = book.Price,
                    InStock = book.Stock > 0,
                    AuthorName = book.Author!.FirstName + " " + book.Author!.LastName,
                    Genre = book.Genre!.Name,
                    PublisherName = book.Publisher!.Name,
                    Description = book.Description,
                    ISBN = book.ISBN,
                    Language = book.Language,
                    PageCount = book.PageCount,
                    PublishYear = book.PublishYear,
                };
            }
            return null;
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

        public async Task<IEnumerable<GenreDto>> GetGenresAsync()
        {
            var genres = await unitOfWork.Genres.FindManyAsync();
            return from genre in genres.ToList()
                   select new GenreDto
                   {
                       Id = genre.Id,
                       Names = genre.Name.Split('|')
                   };
        }

        public async Task<IEnumerable<PublisherDto>> GetPublishersAsync()
        {
            var publishers = await unitOfWork.Publishers.FindManyAsync();
            return from publisher in publishers.ToList()
                   select new PublisherDto
                   {
                       Id = publisher.Id,
                       Name = publisher.Name,
                   };
        }
    }
}
