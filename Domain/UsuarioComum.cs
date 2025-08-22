using GerenciamentoBiblioteca.Domain.Enums;

namespace GerenciamentoBiblioteca.Domain
{
    public class UsuarioComum : Usuario
    {
        public UsuarioComum(string name, string email, string phone, DateTime registerDate)
          : base(name, email, phone, registerDate, EUserType.Common) {}


        public override int MaxBooksLimit => UserType switch
        {
            EUserType.Common => 3,
            _ => throw new InvalidOperationException()
        };

        public override decimal FineByDay => UserType switch
        {
            EUserType.Common => 2.00m,
            _ => throw new InvalidOperationException()
        };

        public override int LoanPeriodDays => UserType switch
        {
            EUserType.Common => 14,
            _ => throw new InvalidOperationException()
        };
    }
}
