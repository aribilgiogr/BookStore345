namespace Core.Concrete.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Picture { get; set; }
        public string? Biography { get; set; }
    }

    public class PublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class GenreDto
    {
        public int Id { get; set; }
        public string[] Names { get; set; } = [];
    }
}
