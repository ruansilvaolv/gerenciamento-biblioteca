using GerenciamentoBiblioteca.Domain.Enums;

namespace GerenciamentoBiblioteca.Domain.Entities
{
    public class Professor : Usuario
    {
        public Professor(string name, string email, string phone, DateTime registerDate)
            : base(name, email, phone, registerDate, EUserType.Teacher) {}

        public override int MaxBooksLimit => UserType switch
        {
            EUserType.Teacher => 10,
            _ => throw new InvalidOperationException()
        };

        public override decimal FineByDay => UserType switch
        {
            EUserType.Teacher => 0m,
            _ => throw new InvalidOperationException()
        };

        public override int LoanPeriodDays => UserType switch
        {
            EUserType.Teacher => 30,
            _ => throw new InvalidOperationException()
        };
    }
}
