using School.Pages.Rooms;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages
{
    public class RoomsPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            var choose = Prompt.Select("Select one of them",
                new[]
                {
                    "1. Get All Rooms",
                    "2. Get by Id Room",
                    "3. Add new Room",
                    "4. Delete Room",
                    "5. Update Room"
                });

            if (choose == "1. Get All Rooms")
                await ReadAllPage.RunAsync();
            else if (choose == "2. Get by Id Room")
                await ReadPage.RunAsync();
            else if (choose == "3. Add new Room")
                await CreatePage.RunAsync();
            else if (choose == "5. Update Room")
                await DeletePage.RunAsync();
            else
                await UpdatePage.RunAsync();
        }
    }
}
