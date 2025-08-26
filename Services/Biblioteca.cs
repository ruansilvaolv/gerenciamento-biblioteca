using GerenciamentoBiblioteca.Domain.Entities;
using GerenciamentoBiblioteca.Domain.Exceptions;
using GerenciamentoBiblioteca.Domain.Entities;
using GerenciamentoBiblioteca.Domain.Factories;
using GerenciamentoBiblioteca.Domain.Enums;

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
            var dadosLivro = ReceberDadosLivro();
            ValidarDadosLivro(dadosLivro);
        }

        public (string bookName, string author, string isbn, int publicationYear) ReceberDadosLivro()
        {
            Console.Write("Digite o nome do livro: ");
            string bookName = Console.ReadLine() ?? "";

            Console.Write("Digite o nome do autor: ");
            string author = Console.ReadLine() ?? "";

            Console.Write("Digite o ISBN: ");
            string isbn = Console.ReadLine() ?? "";

            Console.Write("Digite o ano de publicação: ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int publicationYear))
            {
                if (publicationYear > DateTime.Now.Year)
                {
                    throw new ArgumentException("Ano deve ser igual ou abaixo do ano atual!");
                }
            }
            else
            {
                throw new ArgumentException("Ano inválido!");
            }

            return (bookName, author, isbn, publicationYear);
        }

        public void ValidarDadosLivro((string bookName, string author, string isbn, int publicationYear) dados)
        {
            if (string.IsNullOrWhiteSpace(dados.bookName))
                throw new ArgumentNullException("O título do livro é obrigatório!");

            if (string.IsNullOrWhiteSpace(dados.author))
                throw new ArgumentNullException("O nome do autor é obrigatório!");

            if (string.IsNullOrWhiteSpace(dados.isbn))
                throw new ArgumentNullException("ISBN é obrigatório!");

            if (int.IsNegative(dados.publicationYear))
                throw new ArgumentException("O ano de publicação não pode ser negativo!");
        }

        public void CadastrarUsuario()
        {
            Console.Write("Digite o nome completo: ");
            var name = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            var email = Console.ReadLine();

            Console.Write("Digite o telefone completo: ");
            var phone = Console.ReadLine();

            Console.Write("Digite uma das opções abaixo:\n1 - Usuário Comum\n2 - Estudante\n3 - Professor\n");
            var opt = int.Parse(Console.ReadLine());

            var novoUsuario = UsuarioFactory.CriarUsuario(opt, name, email, phone);
        }

        public void RealizarEmprestimo()
        {}

        public void ProcessarDevolucao()
        {}
    }
}
