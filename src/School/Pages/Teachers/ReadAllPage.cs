using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using System;
using System.Threading.Tasks;

namespace School.Pages.Teachers
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable teachertable = new ConsoleTable("Id", "Full Name", "Age", "Gender", "Subject");

            ITeacherService teacherService = new TeacherService();
            var teachers = await teacherService.GetAllAsync();

            foreach (var teacher in teachers)
            {
                teachertable.AddRow(teacher.TeacherId, teacher.LastName + " " + teacher.FirstName,
                    teacher.Age, teacher.Gender, teacher.Subject);
            }
            teachertable.Write();
            Console.ForegroundColor = ConsoleColor.White;
            await SubFooter.MakeFooterAsync();
        }
    }
}
