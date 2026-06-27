using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using Utils.Generics;

namespace Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(StoreContext context) : base(context)
        {
        }
    }
}
