using GerenciamentoBiblioteca.Domain.Enums;

namespace GerenciamentoBiblioteca.Domain
{
    public class Estudante : Usuario
    {
        public Estudante(string name, string email, string phone, DateTime registerDate)
            : base(name, email, phone, registerDate, EUserType.Student) {}

        public override int MaxBooksLimit => UserType switch
        {
            EUserType.Student => 5,
            _ => throw new InvalidOperationException()
        };

        public override decimal FineByDay => UserType switch
        {
            EUserType.Student => 1.00m,
            _ => throw new InvalidOperationException()
        };

        public override int LoanPrize => UserType switch
        {
            EUserType.Student => 21,
            _ => throw new InvalidOperationException()
        };
    }
}
