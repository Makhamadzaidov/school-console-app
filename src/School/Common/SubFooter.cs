using School.Pages;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Common
{
    public class SubFooter
    {
        public static async Task MakeFooterAsync()
        {
            Console.WriteLine();
            var choose = Prompt.Select("Select one of them",
                new[] {
                    "1. Main Menu",
                    "2. Exit",
                });

            var selectedItem = choose[0];

            if (selectedItem == '1')
                await MainMenuPage.RunAsync();
            else if (selectedItem == '2')
                Environment.Exit(0);
        }
    }
}
