using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
{
    public class Student : User
    {
        public Student(string name, string email, string phone, DateTime registerDate)
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

        public override int LoanPeriodDays => UserType switch
        {
            EUserType.Student => 21,
            _ => throw new InvalidOperationException()
        };
    }
}
