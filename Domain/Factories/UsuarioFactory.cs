using GerenciamentoBiblioteca.Domain.Entities;
using GerenciamentoBiblioteca.Domain.Enums;

namespace GerenciamentoBiblioteca.Domain.Factories
{
    public class UsuarioFactory
    {
        public static Usuario CriarUsuario(int optType, string name, string email, string phone)
        {
            if(!Enum.IsDefined(typeof(EUserType), optType))
            {
                throw new ArgumentException("Opção inválida!");
            }

            EUserType userType = (EUserType)optType;

            return userType switch
            {
                EUserType.Common => new UsuarioComum(name, email, phone, DateTime.Now),
                EUserType.Student => new Estudante(name, email, phone, DateTime.Now),
                EUserType.Teacher => new Professor(name, email, phone, DateTime.Now),
                _ => throw new ArgumentException("Tipo de usuário não implementado!")
            };
        }
    }
}
