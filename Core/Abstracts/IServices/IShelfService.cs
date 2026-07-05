using Core.Concrete.DTOs;

namespace Core.Abstracts.IServices
{
    public interface IShelfService
    {
        Task<IEnumerable<BookListItemDto>> GetBooksAsync();
        Task<BookDetailDto?> GetBookDetailByIdAsync(int id);
        Task<IEnumerable<BookListItemDto>> FilterBooksAsync(FilterDto filter);
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
        Task<IEnumerable<PublisherDto>> GetPublishersAsync();
        Task<IEnumerable<GenreDto>> GetGenresAsync();
    }
}
