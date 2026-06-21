using System.Linq.Expressions;

namespace Utils.Generics
{

    public interface IRepository<T> where T : class
    {
        // INSERT INTO DbSet<T> VALUES (<entity>)
        Task InsertOneAsync(T entity);

        // INSERT INTO DbSet<T> VALUES (<entity 1>),(<entity 2>),...,(<entity n>)
        Task InsertManyAsync(IEnumerable<T> entities);

        // SELECT * FROM DbSet<T> WHERE <PrimaryKey> = <key>
        Task<T?> FindOneAsync(object key);

        // SELECT * FROM DbSet<T> WHERE <where>: where boş (null) olursa bütün kayıtlar gelir.
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes);

        // UPDATE DbSet<T> SET ... WHERE ...
        Task UpdateOneAsync(T entity);
        Task UpdateManyAsync(IEnumerable<T> entities);

        // DELETE FROM DbSet<T> WHERE ...
        Task DeleteOneAsync(object key);
        Task DeleteOneAsync(T entity);
        Task DeleteManyAsync(IEnumerable<T> entities);
        Task DeleteManyAsync(Expression<Func<T, bool>>? where = null);

        // Extras 
        Task<int> CountAsync(Expression<Func<T, bool>>? where = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null);
    }
}
