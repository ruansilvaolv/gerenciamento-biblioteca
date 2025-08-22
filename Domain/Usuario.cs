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


        // Switch Expressions
        public int MaxBooksLimit => UserType switch
        {
            EUserType.Commmon => 3,
            EUserType.Student => 5,
            EUserType.Teacher => 10,
            _ => 0
        };

        public decimal FineByDay => UserType switch
        {
            EUserType.Commmon => 2.00m,
            EUserType.Student => 1.00m,
            EUserType.Teacher => 0m, // Don't pay fine
            _ => 0m
        };

        public int LoanPrize => UserType switch
        {
            EUserType.Commmon => 14,
            EUserType.Student => 21,
            EUserType.Teacher => 30,
            _ => 0
        };


        // Methods
        private bool CheckEmail(string email)
        {
            var validateRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            return validateRegex.IsMatch(email);
        }
    }
}
