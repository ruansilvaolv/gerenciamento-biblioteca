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
          => LoanDate.Day - DevolutionDate.Day;

        public decimal CalcFine()
        {
            int daysLate = CalcDaysLate();

            if (daysLate > 0)
                return User.FineByDay * CalcDaysLate();
            else
            {
                return 0m;
            }
        }

        public void FinalizeLoan()
        {}
    }
}
