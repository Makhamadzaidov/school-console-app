using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages
{
    public class MainMenuPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();

            Symbol symbol = new Symbol("Select one of them", "->");
            Prompt.Symbols.Selector = symbol;

            var choose = Prompt.Select(" ==== Menu ====",
                new[]
                {
                    "1. Teachers List",
                    "2. Pupils List",
                    "3. Rooms List"
                });

            if (choose == "1. Teachers List")
                await TeachersPage.RunAsync();

            else if (choose == "2. Pupils List")
                await PupilsPage.RunAsync();

            else
                await RoomsPage.RunAsync();
        }
    }
}
