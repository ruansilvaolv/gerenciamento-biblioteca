using System.Text.RegularExpressions;
using GerenciamentoBiblioteca.Domain.Enums;
using GerenciamentoBiblioteca.Domain.Exceptions;

namespace GerenciamentoBiblioteca
{
    public abstract class Usuario
    {
        public Usuario(string name, string email, string phone, DateTime registerDate, EUserType userType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            RegisterDate = registerDate;
            UserType = userType;
        }


        // Props
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public EUserType UserType { get; set; }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                try
                {
                  if (CheckEmail(email))
                  {
                      value = email;
                  }
                }
                catch(InvalidEmailException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.OccurencyDate);
                    Console.WriteLine("O e-mail informado é inválido!");
                }
            }
        }


        public abstract int MaxBooksLimit { get; }

        public abstract decimal FineByDay { get; }

        public abstract int LoanPrize { get; }


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
