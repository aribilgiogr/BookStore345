using Core.Abstracts.Bases;

namespace Core.Concrete.Entities
{
    public class Publisher : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }
}
