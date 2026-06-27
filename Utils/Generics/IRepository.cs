using System.Linq.Expressions;

namespace Utils.Generics
{
    /// <summary>
    /// Tüm entity türleri için temel veritabanı işlemlerini (CRUD) tanımlayan generic repository arayüzü.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Tek bir entity'yi veritabanına ekler.
        /// </summary>
        /// <param name="entity">Eklenecek entity nesnesi.</param>
        Task InsertOneAsync(T entity);

        /// <summary>
        /// Birden fazla entity'yi tek seferde veritabanına ekler.
        /// </summary>
        /// <param name="entities">Eklenecek entity koleksiyonu.</param>
        Task InsertManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// Primary key değerine göre tek bir entity'yi getirir.
        /// </summary>
        /// <param name="key">Aranacak kaydın primary key değeri.</param>
        /// <returns>Bulunan entity; kayıt yoksa <c>null</c>.</returns>
        Task<T?> FindOneAsync(object key);

        /// <summary>
        /// Opsiyonel filtre ve ilişkili tablolarla birden fazla entity'yi getirir; filtre verilmezse tüm kayıtları döner.
        /// </summary>
        /// <param name="where">Uygulanacak filtre ifadesi; <c>null</c> verilirse tüm kayıtlar döner.</param>
        /// <param name="includes">JOIN ile yüklenecek navigation property adları.</param>
        /// <returns>Filtreyle eşleşen entity listesi.</returns>
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes);

        /// <summary>
        /// Mevcut bir entity'nin veritabanındaki kaydını günceller.
        /// </summary>
        /// <param name="entity">Güncellenecek entity nesnesi.</param>
        Task UpdateOneAsync(T entity);

        /// <summary>
        /// Birden fazla entity'nin veritabanındaki kayıtlarını toplu olarak günceller.
        /// </summary>
        /// <param name="entities">Güncellenecek entity koleksiyonu.</param>
        Task UpdateManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// Primary key değerine göre tek bir entity'yi veritabanından siler.
        /// </summary>
        /// <param name="key">Silinecek kaydın primary key değeri.</param>
        Task DeleteOneAsync(object key);

        /// <summary>
        /// Verilen entity nesnesini veritabanından siler.
        /// </summary>
        /// <param name="entity">Silinecek entity nesnesi.</param>
        Task DeleteOneAsync(T entity);

        /// <summary>
        /// Verilen entity koleksiyonunu toplu olarak veritabanından siler.
        /// </summary>
        /// <param name="entities">Silinecek entity koleksiyonu.</param>
        Task DeleteManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// Filtreyle eşleşen tüm kayıtları veritabanından siler; filtre verilmezse tüm kayıtları siler.
        /// </summary>
        /// <param name="where">Silinecek kayıtları belirleyen filtre ifadesi; <c>null</c> verilirse tüm kayıtlar silinir.</param>
        Task DeleteManyAsync(Expression<Func<T, bool>>? where = null);

        /// <summary>
        /// Filtreyle eşleşen kayıt sayısını döner; filtre verilmezse toplam kayıt sayısını döner.
        /// </summary>
        /// <param name="where">Sayılacak kayıtları belirleyen filtre ifadesi; <c>null</c> verilirse tüm kayıtlar sayılır.</param>
        /// <returns>Eşleşen kayıt sayısı.</returns>
        Task<int> CountAsync(Expression<Func<T, bool>>? where = null);

        /// <summary>
        /// Filtreyle eşleşen herhangi bir kaydın var olup olmadığını kontrol eder; filtre verilmezse tabloda en az bir kayıt olup olmadığını döner.
        /// </summary>
        /// <param name="where">Kontrol edilecek kayıtları belirleyen filtre ifadesi; <c>null</c> verilirse tüm tablo kontrol edilir.</param>
        /// <returns>Eşleşen kayıt varsa <c>true</c>, yoksa <c>false</c>.</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null);
    }
}