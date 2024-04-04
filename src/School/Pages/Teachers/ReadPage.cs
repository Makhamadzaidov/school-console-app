using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Teachers
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            ConsoleTable teachertable = new ConsoleTable("Id", "Full Name", "Age", "Gender", "Subject");
            ITeacherService teacherService = new TeacherService();

            int id = Prompt.Input<int>("Id");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var teacher = await teacherService.GetAsync(id);

            teachertable.AddRow(teacher.TeacherId, teacher.LastName + " " + teacher.FirstName,
                teacher.Age, teacher.Gender, teacher.Subject);

            teachertable.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
