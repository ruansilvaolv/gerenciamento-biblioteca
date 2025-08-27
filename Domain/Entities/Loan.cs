using GerenciamentoBiblioteca.Domain.Enums;

namespace GerenciamentoBiblioteca.Domain.Entities
{
    public class Loan
    {
        public Loan(User user, Book book, DateTime loanDate, DateTime devolutionDate, EUserType userType)
        {
            Id = Guid.NewGuid();
            User = user;
            Book = book;
            LoanDate = loanDate;
            DevolutionDate = devolutionDate;
            UserType = userType;
        }

        public Guid Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DevolutionDate { get; set; }
        public EUserType UserType { get; }

        public int CalcDaysLate()
          =>  DevolutionDate.Day - LoanDate.Day;

        public decimal CalcFine()
          => User.FineByDay * CalcDaysLate();

        public void FinalizeLoan()
        {}
    }
}
