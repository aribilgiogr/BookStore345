using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utils.Generics
{
    /// <summary>
    /// IRepository arayüzünün Entity Framework Core kullanarak somut veritabanı işlemlerini gerçekleştiren soyut taban sınıfı.
    /// </summary>
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        /// <summary>
        /// DbContext bağımlılığını alır ve ilgili entity için DbSet referansını başlatır.
        /// </summary>
        /// <param name="context">Kullanılacak Entity Framework DbContext örneği.</param>
        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        /// <summary>
        /// Filtreyle eşleşen herhangi bir kaydın varlığını veritabanı tarafında sorgular.
        /// </summary>
        /// <param name="where">Kontrol edilecek kayıtları belirleyen filtre ifadesi; <c>null</c> verilirse tüm tablo kontrol edilir.</param>
        /// <returns>Eşleşen kayıt varsa <c>true</c>, yoksa <c>false</c>.</returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null) => await _set.AnyAsync(where ?? (x => true));

        /// <summary>
        /// Filtreyle eşleşen kayıt sayısını veritabanı tarafında hesaplar.
        /// </summary>
        /// <param name="where">Sayılacak kayıtları belirleyen filtre ifadesi; <c>null</c> verilirse tüm kayıtlar sayılır.</param>
        /// <returns>Eşleşen kayıt sayısı.</returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null) => await _set.CountAsync(where ?? (x => true));

        /// <summary>
        /// Verilen entity koleksiyonunu DbSet'ten toplu olarak kaldırır.
        /// </summary>
        /// <param name="entities">Silinecek entity koleksiyonu.</param>
        public async Task DeleteManyAsync(IEnumerable<T> entities) => await Task.Run(() => _set.RemoveRange(entities));

        /// <summary>
        /// Filtreyle eşleşen kayıtları sorgulayıp toplu olarak DbSet'ten kaldırır.
        /// </summary>
        /// <param name="where">Silinecek kayıtları belirleyen filtre ifadesi; <c>null</c> verilirse tüm kayıtlar silinir.</param>
        public async Task DeleteManyAsync(Expression<Func<T, bool>>? where = null)
        {
            var entities = await FindManyAsync(where);
            _set.RemoveRange(entities);
        }

        /// <summary>
        /// Primary key ile kaydı bulup DbSet'ten kaldırır; kayıt bulunamazsa işlem yapmaz.
        /// </summary>
        /// <param name="key">Silinecek kaydın primary key değeri.</param>
        public async Task DeleteOneAsync(object key)
        {
            var entity = await FindOneAsync(key);
            if (entity != null)
            {
                await DeleteOneAsync(entity);
            }
        }

        /// <summary>
        /// Verilen entity nesnesini DbSet'ten kaldırır.
        /// </summary>
        /// <param name="entity">Silinecek entity nesnesi.</param>
        public async Task DeleteOneAsync(T entity) => await Task.Run(() => _set.Remove(entity));

        /// <summary>
        /// Filtreyi ve include'ları IQueryable üzerinde oluşturup sorguyu veritabanında çalıştırarak sonucu liste olarak döner.
        /// </summary>
        /// <param name="where">Uygulanacak filtre ifadesi; <c>null</c> verilirse tüm kayıtlar döner.</param>
        /// <param name="includes">JOIN ile yüklenecek navigation property adları.</param>
        /// <returns>Filtreyle eşleşen entity listesi.</returns>
        public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes)
        {
            IQueryable<T> data = _set.Where(where ?? (x => true));

            foreach (var include in includes)
            {
                data = data.Include(include);
            }

            return await data.ToListAsync();
        }

        /// <summary>
        /// Primary key değerine göre DbSet üzerinden tek bir entity'yi asenkron olarak getirir.
        /// </summary>
        /// <param name="key">Aranacak kaydın primary key değeri.</param>
        /// <returns>Bulunan entity; kayıt yoksa <c>null</c>.</returns>
        public async Task<T?> FindOneAsync(object key) => await _set.FindAsync(key);

        /// <summary>
        /// Birden fazla entity'yi DbSet'e toplu olarak ekler.
        /// </summary>
        /// <param name="entities">Eklenecek entity koleksiyonu.</param>
        public async Task InsertManyAsync(IEnumerable<T> entities) => await _set.AddRangeAsync(entities);

        /// <summary>
        /// Tek bir entity'yi DbSet'e asenkron olarak ekler.
        /// </summary>
        /// <param name="entity">Eklenecek entity nesnesi.</param>
        public async Task InsertOneAsync(T entity) => await _set.AddAsync(entity);

        /// <summary>
        /// Birden fazla entity'nin izleme durumunu Modified olarak işaretleyerek toplu güncellemeye hazırlar.
        /// </summary>
        /// <param name="entities">Güncellenecek entity koleksiyonu.</param>
        public async Task UpdateManyAsync(IEnumerable<T> entities) => await Task.Run(() => _set.UpdateRange(entities));

        /// <summary>
        /// Tek bir entity'nin izleme durumunu Modified olarak işaretleyerek güncellemeye hazırlar.
        /// </summary>
        /// <param name="entity">Güncellenecek entity nesnesi.</param>
        public async Task UpdateOneAsync(T entity) => await Task.Run(() => _set.Update(entity));
    }
}