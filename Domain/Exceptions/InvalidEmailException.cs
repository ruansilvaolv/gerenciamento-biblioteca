namespace GerenciamentoBiblioteca.Domain.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(DateTime time)
        {
            OccurencyDate = time;
        }

        public DateTime OccurencyDate { get; set; }
    }
}
