using Core.Abstracts.Bases;

namespace Core.Concrete.Entities
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; } // Örn: Drama|Fantasy|Horror|Mystery|Thriller veya Comedy
        public virtual ICollection<Book> Books { get; set; } = [];
    }
}
