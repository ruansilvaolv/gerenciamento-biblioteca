using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Factories;

namespace GerenciamentoBiblioteca.Services
{
    public class Library
    {
        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
            Loans = new List<Loan>();
        }

        #region Properties
          public List<Book> Books { get; set; }
          public List<User> Users { get; set; }
          public List<Loan> Loans { get; set; }
        #endregion


        #region Register Books Methods
          public (string bookName, string author, string isbn, int publicationYear) ReceiveBookData()
          {
              Console.Write("Digite o nome do livro: ");
              string bookName = Console.ReadLine() ?? "";

              Console.Write("Digite o nome do autor: ");
              string author = Console.ReadLine() ?? "";

              Console.Write("Digite o ISBN: ");
              string isbn = Console.ReadLine() ?? "";

              Console.Write("Digite o ano de publicação: ");
              string input = Console.ReadLine() ?? "";

              if (int.TryParse(input, out int publicationYear))
              {
                  if (publicationYear > DateTime.Now.Year)
                  {
                      throw new ArgumentException("Ano deve ser igual ou abaixo do ano atual!");
                  }
              }
              else
              {
                  throw new ArgumentException("Ano inválido!");
              }

              return (bookName, author, isbn, publicationYear);
          }

          public void ValidateBookData((string bookName, string author, string isbn, int publicationYear) data)
          {
              if (string.IsNullOrWhiteSpace(data.bookName))
                  throw new ArgumentNullException("O título do livro é obrigatório!");

              if (string.IsNullOrWhiteSpace(data.author))
                  throw new ArgumentNullException("O nome do autor é obrigatório!");

              if (string.IsNullOrWhiteSpace(data.isbn))
                  throw new ArgumentNullException("ISBN é obrigatório!");

              if (int.IsNegative(data.publicationYear))
                  throw new ArgumentException("O ano de publicação não pode ser negativo!");
          }

          public void RegisterBook()
          {
              var bookData = ReceiveBookData();
              ValidateBookData(bookData);
              var (bookName, author, isbn, publicationYear) = bookData;
              var book = BookFactory.CreateBook(bookName, author, isbn, publicationYear);

              Books.Add(book);
          }
        #endregion)


        #region Register Users Methods
          public (string userName, string userEmail, string userPhone, int userOpt) ReceiveUserData()
          {
              Console.Write("Digite o nome completo: ");
              string userName = Console.ReadLine() ?? "";

              Console.Write("Digite o e-mail: ");
              string userEmail = Console.ReadLine() ?? "";

              Console.Write("Digite o telefone: ");
              string userPhone = Console.ReadLine() ?? "";

              Console.Write("Digite opção desejada: ");
              string opt = Console.ReadLine() ?? "";

              int.TryParse(opt, out int userOpt);

              return (userName, userEmail, userPhone, userOpt);
          }

          public void ValidateUserData((string userName, string userEmail, string userPhone, int userOpt) data)
          {
              if (string.IsNullOrWhiteSpace(data.userName))
                throw new ArgumentNullException("O nome é obrigatório!");

              if (string.IsNullOrWhiteSpace(data.userEmail))
                throw new ArgumentNullException("O e-mail é obrigatório!");

              if (string.IsNullOrWhiteSpace(data.userPhone))
                throw new ArgumentNullException("O telefone é obrigatório!");

              if (data.userOpt < 1 || data.userOpt > 3)
                throw new ArgumentException("Opção inválida!");
          }

          public void RegisterUser()
          {
              var userData = ReceiveUserData();
              ValidateUserData(userData);
              var (userName, userEmail, userPhone, userOpt) = userData;
              var user = UserFactory.CreateUser(userOpt, userName, userEmail, userPhone);

              Users.Add(user);
          }
        #endregion


        public void MakeLoan()
        {}

        public void ProcessReturn()
        {}
    }
}
