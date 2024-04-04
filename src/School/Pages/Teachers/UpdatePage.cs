using ConsoleTables;
using School.Common;
using School.Enums;
using School.Interfaces.ServiceInterfaces;
using School.Models;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Teachers
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable teachertable = new ConsoleTable("Id", "Full Name", "Age", "Gender", "Subject");

            ITeacherService teacherService = new TeacherService();
            var teachers = await teacherService.GetAllAsync();

            foreach (var teacherr in teachers)
            {
                teachertable.AddRow(teacherr.TeacherId, teacherr.LastName + " " + teacherr.FirstName,
                    teacherr.Age, teacherr.Gender, teacherr.Subject);
            }
            teachertable.Write();
            Console.ForegroundColor = ConsoleColor.White;

            Teacher teacher = new Teacher();
            teacher.TeacherId = Prompt.Input<int>("Id");
            teacher.FirstName = Prompt.Input<string>("First Name");
            teacher.LastName = Prompt.Input<string>("Last Name");
            teacher.Age = Prompt.Input<int>("Age");
            Console.WriteLine("1. Male    2. Female");
            teacher.Gender = Prompt.Input<Gender>("Gender") - 1;

            Console.WriteLine("1. Adabiyot,      2. Ona Tili,    3. Rus Tili");
            Console.WriteLine("4. Ingliz Tili,   5. Algebra,     6. Fizika");
            Console.WriteLine("7. Geometriya,    8. Infarmatika, 9. Kimyo");
            teacher.Subject = Prompt.Input<Subject>("Subject") - 1;

            teacher.Salary = Prompt.Input<int>("Salary");
            teacher.Address = Prompt.Input<string>("Address");
            teacher.Login = Prompt.Input<string>("New Login");
            teacher.Password = Prompt.Password("New Password");

            var oldLogin = Prompt.Input<string>("Enter old Login");
            var oldPassword = Prompt.Password("Enter old Password");

            bool check = await teacherService.UpdateAsync(teacher.TeacherId, oldLogin, oldPassword, teacher);

            if (check is true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccessfully Updated");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLogin or Password is Wrong");
                Console.ForegroundColor = ConsoleColor.White;
            }
            await SubFooter.MakeFooterAsync();
        }
    }
}
