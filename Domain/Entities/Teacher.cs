using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
{
    public class Teacher : User
    {
        public Teacher(string name, string email, string phone, DateTime registerDate)
            : base(name, email, phone, registerDate, EUserType.Teacher) {}

        public override int MaxBooksLimit => 10;
        public override decimal FineByDay => 0m;
        public override int LoanPeriodDays => 30;
    }
}
