using System;

namespace Fisher.Bookstore.Api.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public List<Book> Titles { get; set; }
    }
}