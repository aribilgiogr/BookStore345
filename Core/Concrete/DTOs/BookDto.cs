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
        public int AuthorId { get; set; }
        public string Genre { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public int PublisherId { get; set; }
    }

    public class BookDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public required string ISBN { get; set; }
        public string? CoverImagePath { get; set; } // 400x600
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string AuthorName { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
        public string? Language { get; set; }
    }

    public class FilterDto
    {
        public string? SearchTerm { get; set; }
        public int? SelectedAuthorId { get; set; }
        public int? SelectedPublisherId { get; set; }
        public string? SelectedGenreName { get; set; }
    }
}
