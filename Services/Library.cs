using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Factories;
using LibraryManagement.UI;

namespace LibraryManagement.Services
{
    public class Library
    {
        public Library(IUIHelper ui)
        {
            Books = new List<Book>();
            Users = new List<User>();
            Loans = new List<Loan>();

            _ui = ui;
        }

        #region Properties
          public List<Book> Books { get; }
          public List<User> Users { get; }
          public List<Loan> Loans { get; }

          private IUIHelper _ui;
        #endregion


        #region Register Books Methods
          public (string bookName, string author, string isbn, int publicationYear) ReceiveBookData()
          {
              string bookName = _ui.ReadString("Título: ");

              string author = _ui.ReadString("Nome do autor: ");

              string isbn = _ui.ReadString("Digite o ISBN: ");

              string yearInput = _ui.ReadString("Digite o ano de publicação: ");

              if (int.TryParse(yearInput, out int publicationYear))
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
              string userName = _ui.ReadString("Nome completo: ");

              string userEmail = _ui.ReadString("Digite o e-mail: ");

              string userPhone = _ui.ReadString("Digite o telefone: ");

              string opt = _ui.ReadString("Digite opção desejada:\n1 - Usuário Comum\n2 - Estudante\n3 - Professor\n");

              if(int.TryParse(opt, out int userOpt))
              {
                  if (userOpt <= 0 || userOpt > 3)
                  {
                      throw new ArgumentException("Opção inválida!");
                  }
              }
              else
              {
                  throw new ArgumentException("Opção inválida!");
              }

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
