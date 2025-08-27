using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Factories
{
    public class UserFactory
    {
        public static User CreateUser(int optType, string name, string email, string phone)
        {
            if(!Enum.IsDefined(typeof(EUserType), optType))
            {
                throw new ArgumentException("Opção inválida!");
            }

            EUserType userType = (EUserType)optType;

            return userType switch
            {
                EUserType.Common => new CommonUser(name, email, phone, DateTime.Now),
                EUserType.Student => new Student(name, email, phone, DateTime.Now),
                EUserType.Teacher => new Teacher(name, email, phone, DateTime.Now),
                _ => throw new ArgumentException("Tipo de usuário não implementado!")
            };
        }
    }
}
