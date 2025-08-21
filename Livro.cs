namespace GerenciamentoBiblioteca
{
    public class Livro
    {
        public Livro(string title, string author, string isbn, DateTime anoPublicacao, bool isAvailable = true)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime AnoPublicacao { get; set; }
        public bool IsAvailable { get; set; }

        public void MarcarEmprestado()
        {}

        public void MarcarDisponivel()
        {}
    }
}
