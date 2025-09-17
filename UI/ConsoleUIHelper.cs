namespace LibraryManagement.UI
{
    public class ConsoleUIHelper : IUIHelper
    {
        public string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()!;
        }

        public int ReadInt(int prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine()!);
        }
    }
}
