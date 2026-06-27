using Core.Abstracts.IRepositories;
using Utils.Responses;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        IPublisherRepository Publishers { get; }
        IGenreRepository Genres { get; }

        Task<IReply<int>> CommitAsync(CancellationToken cancellationToken = default);
    }
}
