using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Utils.Responses;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext context;

        public UnitOfWork(StoreContext context)
        {
            this.context = context;
        }

        private IBookRepository? books;
        public IBookRepository Books => books ??= new BookRepository(context);

        private IAuthorRepository? authors;
        public IAuthorRepository Authors => authors ??= new AuthorRepository(context);

        private IPublisherRepository? publishers;
        public IPublisherRepository Publishers => publishers ??= new PublisherRepository(context);

        private IGenreRepository? genres;
        public IGenreRepository Genres => genres ??= new GenreRepository(context);

        public async Task<IReply<int>> CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                int rows = await context.SaveChangesAsync(cancellationToken);
                return ReplyFactory.Success(rows, "İşlem başarıyla tamamlandı!");
            }
            catch (DbUpdateException ex)
            {
                return ReplyFactory.Fail(0, "Veritabanı kaydı sırasında bir hata oluştu.", [ex.Message]);
            }
            catch (Exception ex)
            {
                return ReplyFactory.Fail(0, "Beklenmeyen bir sistem hatası oluştu.", [ex.Message]);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
