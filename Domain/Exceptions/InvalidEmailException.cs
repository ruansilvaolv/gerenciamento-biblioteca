namespace LibraryManagement.Domain.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message)
        {
            OccurencyMessage = message;
        }

        public string OccurencyMessage { get; set; }
    }
}
