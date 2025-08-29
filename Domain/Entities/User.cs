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
            if (!CheckEmail(email))
                throw new InvalidEmailException("O e-mail informado é inválido!");
            Email = email;
            Phone = phone;
            RegisterDate = registerDate;
            UserType = userType;
        }

        // Props
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public EUserType UserType { get; set; }


        public abstract int MaxBooksLimit { get; }

        public abstract decimal FineByDay { get; }

        public abstract int LoanPeriodDays { get; }


        // Methods
        private bool CheckEmail(string email)
        {
            var validateRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            return validateRegex.IsMatch(email);
        }

        public decimal CalcLoanTotal(int daysLate)
            => FineByDay * daysLate;
    }
}
