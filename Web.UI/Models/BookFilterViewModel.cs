using Core.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.UI.Models
{
    public class BookFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public int? SelectedAuthorId { get; set; }
        public int? SelectedPublisherId { get; set; }
        public int? SelectedGenreId { get; set; }

        public IEnumerable<SelectListItem>? Authors { get; set; }
        public IEnumerable<SelectListItem>? Publishers { get; set; }
        public IEnumerable<SelectListItem>? Genres { get; set; }

        public List<BookListItemDto> Books { get; set; } = [];
    }
}
