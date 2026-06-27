using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using Utils.Generics;

namespace Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(StoreContext context) : base(context)
        {
        }
    }
}
