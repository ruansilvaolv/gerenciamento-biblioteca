using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Domain.Factories
{
    public class BookFactory
    {
        public static Book CreateBook(string bookName, string author, string isbn, int publicationYear)
        {
            return new Book(bookName, author, isbn, publicationYear);
        }
    }
}
