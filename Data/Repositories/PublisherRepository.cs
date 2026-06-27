using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using Utils.Generics;

namespace Data.Repositories
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(StoreContext context) : base(context)
        {

        }
    }
}
