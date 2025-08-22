namespace GerenciamentoBiblioteca.Services
{
    public class Biblioteca
    {
        public Biblioteca()
        {
            Livros = new List<Livro>();
            Usuarios = new List<Usuario>();
            Emprestimos = new List<Emprestimo>();
        }

        public List<Livro> Livros { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public void CadastrarLivro()
        {
            Console.Write("Digite o nome do livro: ");
            string BookName = Console.ReadLine();

            Console.Write("Digite  o nome do Autor: ");
            string Author = Console.ReadLine();

            Console.Write("Digite  o ISBN: ");
            string Isbn = Console.ReadLine();

            Console.Write("Digite o ano de publicação: ");
            DateTime AnoPublicacao = DateTime.Parse(Console.ReadLine());

            Livro book = new Livro(BookName, Author, Isbn, AnoPublicacao);

            Livros.Add(book);
        }

        public void CadastrarUsuario()
        {}

        public void RealizarEmprestimo()
        {}

        public void ProcessarDevolucao()
        {}
    }
}
