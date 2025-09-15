namespace LibraryManagement.UI
{
    public class ConsoleUIHelper : UIHelper
    {
        public override string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()!;
        }

        public override int ReadInt(int prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine()!);
        }
    }
}
