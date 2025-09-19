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

              int publicationYear = _ui.ReadInt("Digite o ano de publicação: ");

              return (bookName, author, isbn, publicationYear);
          }

          public void RegisterBook()
          {
              var bookData = ReceiveBookData();
              Validator.ValidateBook(bookData);
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

              int userOpt = _ui.ReadInt("Digite opção desejada:\n1 - Usuário Comum\n2 - Estudante\n3 - Professor\n");

              return (userName, userEmail, userPhone, userOpt);
          }

          public void RegisterUser()
          {
              var userData = ReceiveUserData();
              Validator.ValidateUser(userData);
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
