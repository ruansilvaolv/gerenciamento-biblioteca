using GerenciamentoBiblioteca.Domain.Enums;

namespace GerenciamentoBiblioteca.Domain.Entities
{
    public class Emprestimo
    {
        public Emprestimo(Usuario usuario, Livro livro, DateTime loanDate, DateTime devolutionDate, EUserType userType)
        {
            Id = Guid.NewGuid();
            Usuario = usuario;
            Livro = livro;
            LoanDate = loanDate;
            DevolutionDate = devolutionDate;
            UserType = userType;
        }

        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DevolutionDate { get; set; }
        public EUserType UserType { get; }

        public int CalcDaysLate()
          =>  DevolutionDate.Day - LoanDate.Day;

        public decimal CalcFine()
          => Usuario.FineByDay * CalcDaysLate();

        public void FinalizeLoan()
        {}
    }
}
