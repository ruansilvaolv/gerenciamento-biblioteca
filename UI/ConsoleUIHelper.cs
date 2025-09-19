namespace LibraryManagement.UI
{
    public class ConsoleUIHelper : IUIHelper
    {
        public string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()!;
        }

        public int ReadInt(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(prompt, out int value))
                return value;
            else
            {
                throw new ArgumentException("Você deve digitar um valor numérico inteiro!");
            }
        }
    }
}
