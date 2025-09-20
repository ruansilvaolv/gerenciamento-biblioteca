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

        public int InitMainLoop()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao sistem de gerenciamento de Biblioteca!\n");

            var menuOpt = 0;

            do
            {
                menuOpt = ReadInt("Digite a opção desejada:\n1 - Cadastrar Livro\n2 - Cadastrar Usuário\n0 - Sair");
                if (menuOpt < 0 || menuOpt > 2)
                    throw new ArgumentException("Opção desejada não existe!");

            } while (menuOpt != 0);

            return menuOpt;
        }
    }
}
