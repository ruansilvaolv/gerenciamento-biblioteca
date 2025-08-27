namespace GerenciamentoBiblioteca.Domain.Entities
{
    public class Book
    {
        public Book(string title, string author, string isbn, int publicationYear, bool isAvailable = true)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Isbn = isbn;
            PublicationYear = publicationYear;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        public void MarkBorrowed()
        {}

        public void MarkAvailable()
        {}
    }
}
