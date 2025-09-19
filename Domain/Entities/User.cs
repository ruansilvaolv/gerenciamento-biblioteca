using System.Text.RegularExpressions;
using LibraryManagement.Domain.Enums;
using LibraryManagement.Domain.Exceptions;

namespace LibraryManagement.Domain.Entities
{
    public abstract class User
    {
        public User(string name, string email, string phone, DateTime registerDate, EUserType userType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            RegisterDate = registerDate;
            UserType = userType;
        }

        // Props
        public Guid Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; }
        public EUserType UserType { get; set; }


        public abstract int MaxBooksLimit { get; }

        public abstract decimal FineByDay { get; }

        public abstract int LoanPeriodDays { get; }


        // Methods
        public decimal CalcLoanTotal(int daysLate)
            => FineByDay * daysLate;
    }
}
