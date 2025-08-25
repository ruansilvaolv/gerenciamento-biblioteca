using GerenciamentoBiblioteca.Domain;
using GerenciamentoBiblioteca.Domain.Exceptions;

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
        {
            Console.Write("Digite o nome completo: ");
            var name = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            var email = Console.ReadLine();

            Console.Write("Digite o telefone completo: ");
            var phone = Console.ReadLine();

            Console.Write("Digite uma das opções abaixo:\n1 - Usuário Comum\n2 - Estudante\n3 - Professor\n");
            var opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    var commonUser = new UsuarioComum(name, email, phone, DateTime.Now);
                    Usuarios.Add(commonUser);
                    break;
                case 2:
                    var studentUser = new Estudante(name, email, phone, DateTime.Now);
                    Usuarios.Add(studentUser);
                    break;
                case 3:
                    var teacherUser = new Professor(name, email, phone, DateTime.Now);
                    Usuarios.Add(teacherUser);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    throw new InvalidRegisterOptionException(DateTime.Now);
                    break;
            }
        }

        public void RealizarEmprestimo()
        {}

        public void ProcessarDevolucao()
        {}
    }
}
