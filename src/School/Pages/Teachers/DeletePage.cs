using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Teachers
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable teachertable = new ConsoleTable("Id", "Full Name", "Age", "Gender", "Subject");

            ITeacherService teacherService = new TeacherService();
            var teachers = await teacherService.GetAllAsync();

            foreach (var teacher in teachers)
                teachertable.AddRow(teacher.TeacherId, teacher.LastName + " " + teacher.FirstName,
                    teacher.Age, teacher.Gender, teacher.Subject);
            teachertable.Write();
            Console.ForegroundColor = ConsoleColor.White;

            int id = Prompt.Input<int>("Enter Id");
            string login = Prompt.Input<string>("Login");
            string password = Prompt.Password("Password");

            bool check = await teacherService.DeleteAsync(id, login, password);
            if (check)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccesfully Deleted");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLogin or Password is Wrong");
                Console.ForegroundColor = ConsoleColor.White;
            }
            await SubFooter.MakeFooterAsync();
        }
    }
}
