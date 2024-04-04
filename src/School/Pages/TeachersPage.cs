using School.Pages.Teachers;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages
{
    public class TeachersPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            var choose = Prompt.Select("Select one of them",
                new[]
                {
                    "1. Get All Teacher",
                    "2. Get by Id Teacher",
                    "3. Add new Teacher",
                    "4. Delete Teacher",
                    "5. Update Teacher"
                });

            if (choose == "1. Get All Teacher")
                await ReadAllPage.RunAsync();
            else if (choose == "2. Get by Id Teacher")
                await ReadPage.RunAsync();
            else if (choose == "3. Add new Teacher")
                await CreatePage.RunAsync();
            else if (choose == "4. Delete Teacher")
                await DeletePage.RunAsync();
            else
                await UpdatePage.RunAsync();

        }
    }
}
