using LibraryManagement.Application.Interfaces;

namespace LibraryManagement.Infraestructure.UI
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
            string value = Console.ReadLine()!;
            if (int.TryParse(value, out int convertedValue))
                return convertedValue;
            else
            {
                throw new ArgumentException("Você deve digitar um valor numérico inteiro!");
            }
        }
    }
}
