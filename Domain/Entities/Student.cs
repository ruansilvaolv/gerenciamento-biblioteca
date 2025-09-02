using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
{
    public class Student : User
    {
        public Student(string name, string email, string phone, DateTime registerDate)
            : base(name, email, phone, registerDate, EUserType.Student) {}

        public override int MaxBooksLimit => 5;
        public override decimal FineByDay => 1.00m;
        public override int LoanPeriodDays => 21;
    }
}
