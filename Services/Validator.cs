namespace LibraryManagement.Services
{
    public static class Validator
    {
        public static void ValidateBook((string bookName, string author, string isbn, int publicationYear) data)
        {
            if (string.IsNullOrWhiteSpace(data.bookName))
                throw new ArgumentNullException("O título do livro é obrigatório!");

            if (string.IsNullOrWhiteSpace(data.author))
                throw new ArgumentNullException("O nome do autor é obrigatório!");

            if (string.IsNullOrWhiteSpace(data.isbn))
                throw new ArgumentNullException("ISBN é obrigatório!");

            if (data.publicationYear > DateTime.Now.Year)
                throw new ArgumentException("Ano deve ser igual ou abaixo do ano atual!");
        }

        public static void ValidateUser((string userName, string userEmail, string userPhone, int userOpt) data)
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
    }
}
