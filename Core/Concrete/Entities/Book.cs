using Core.Abstracts.Bases;

namespace Core.Concrete.Entities
{
    public class Book : BaseEntity
    {
        public required string Title { get; set; }
        public string? CoverImagePath { get; set; }
        public string? Description { get; set; }
        public required string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; } = 0;
        public string? Language { get; set; }
    }
}
