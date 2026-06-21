using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utils.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null) => await _set.AnyAsync(where ?? (x => true));

        public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null) => await _set.CountAsync(where ?? (x => true));

        public async Task DeleteManyAsync(IEnumerable<T> entities) => await Task.Run(() => _set.RemoveRange(entities));

        public async Task DeleteManyAsync(Expression<Func<T, bool>>? where = null)
        {
            var entities = await FindManyAsync(where);
            _set.RemoveRange(entities);
        }

        public async Task DeleteOneAsync(object key)
        {
            var entity = await FindOneAsync(key);
            if (entity != null)
            {
                await DeleteOneAsync(entity);
            }
        }

        public async Task DeleteOneAsync(T entity) => await Task.Run(() => _set.Remove(entity));

        public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes)
        {
            // IQueryable: Veritabanı yapısının koleksiyonudur, gerekli sorgu bu yolla hazırlanırsa her şey veritabanı sunucusunda işlenir, uygulama tarafında performans sağlar.
            IQueryable<T> data = _set.Where(where ?? (x => true));

            // Include: IQueryable ile çalışır, veritabanı tarafında JOIN işlemlerini sorguya dahil eder.
            foreach (var include in includes)
            {
                data = data.Include(include); // Her foreign key tablosu için JOIN ekler.
            }

            return await data.ToListAsync(); // Sorgu nesneye dönüşmek zorundadır.
        }

        public async Task<T?> FindOneAsync(object key) => await _set.FindAsync(key);

        public async Task InsertManyAsync(IEnumerable<T> entities) => await _set.AddRangeAsync(entities);

        public async Task InsertOneAsync(T entity) => await _set.AddAsync(entity);

        public async Task UpdateManyAsync(IEnumerable<T> entities) => await Task.Run(() => _set.UpdateRange(entities));

        public async Task UpdateOneAsync(T entity) => await Task.Run(() => _set.Update(entity));
    }
}
