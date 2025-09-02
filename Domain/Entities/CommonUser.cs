using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
{
    public class CommonUser : User
    {
        public CommonUser(string name, string email, string phone, DateTime registerDate)
          : base(name, email, phone, registerDate, EUserType.Common) {}

        public override int MaxBooksLimit => 3;
        public override decimal FineByDay => 2.00m;
        public override int LoanPeriodDays => 14;
    }
}
