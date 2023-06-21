using BookApp.API.Models.Book;

namespace BookApp.API.Models.Author
{
    public class AuthorDetailsDto : AuthorReadOnlyDto
    {
        public List<BookReadOnlyDto> Books { get; set; }
    }
}