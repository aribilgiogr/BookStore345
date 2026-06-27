using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.Entities
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }

    public class Author : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Picture { get; set; }
        public string? Biography { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }

    public class Publisher : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }

    public class Book : BaseEntity
    {
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }
    }
}
