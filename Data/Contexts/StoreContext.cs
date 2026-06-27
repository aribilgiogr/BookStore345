using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
    }
}
