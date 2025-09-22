using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
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

        public Guid Id { get; }
        public User User { get; }
        public Book Book { get; }
        public DateTime LoanDate { get; }
        public DateTime DevolutionDate { get; }
        public EUserType UserType { get; }

        public int CalcDaysLate()
          =>  DevolutionDate.Day - LoanDate.Day;

        public decimal CalcFine()
          => User.FineByDay * CalcDaysLate();

        public void FinalizeLoan()
        {}
    }
}
