using School.Pages.Pupils;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages
{
    public class PupilsPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            var choose = Prompt.Select("Select one of them",
                new[]
                {
                    "1. Get All Pupil",
                    "2. Get by Id Pupil",
                    "3. Add new Pupil",
                    "4. Delete Pupil",
                    "5. Update Pupil"
                });

            if (choose == "1. Get All Pupil")
                await ReadAllPage.RunAsync();
            else if (choose == "2. Get by Id Pupil")
                await ReadPage.RunAsync();
            else if (choose == "3. Add new Pupil")
                await CreatePage.RunAsync();
            else if (choose == "4. Delete Pupil")
                await DeletePage.RunAsync();
            else
                await UpdatePage.RunAsync();
        }
    }
}
