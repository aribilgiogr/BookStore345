using Core.Concrete.DTOs;

namespace Core.Abstracts.IServices
{
    public interface IShelfService
    {
        Task<IEnumerable<BookListItemDto>> GetBooksAsync();
        Task<BookDetailDto?> GetBookDetailByIdAsync(int id);
    }
}
