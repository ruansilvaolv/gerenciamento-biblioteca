namespace GerenciamentoBiblioteca.Domain.Exceptions
{
    public class InvalidRegisterOptionException : Exception
    {
        public InvalidRegisterOptionException(DateTime time)
        {
            OccurencyDate = time;
        }

        public DateTime OccurencyDate { get; set; }
    }
}
