namespace GerenciamentoBiblioteca
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
        {}

        public void CadastrarUsuario()
        {}

        public void RealizarEmprestimo()
        {}

        public void ProcessarDevolucao()
        {}
    }
}
