using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using Utils.Generics;

namespace Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(StoreContext context) : base(context)
        {

        }
    }
}
