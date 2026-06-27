using Core.Abstracts.Bases;

namespace Core.Concrete.Entities
{
    public class Author : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Picture { get; set; }
        public string? Biography { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }
}
