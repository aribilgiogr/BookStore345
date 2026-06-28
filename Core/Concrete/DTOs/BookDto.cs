namespace Core.Concrete.DTOs
{
    public class BookListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? CoverImagePath { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string AuthorName { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
    }

    public class BookDetailDto
    {

    }
}
