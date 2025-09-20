using LibraryManagement.Services;
using LibraryManagement.UI;

namespace LibraryManagement;

class Program
{
    static void Main(string[] args)
    {
        var ui = new ConsoleUIHelper();
        var library = new Library(ui);
        var consoleUI = new LibraryConsoleUI(library, ui);

        consoleUI.Run();
    }
}
