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
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            ITeacherService teacherService = new TeacherService();
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
            teacher.Login = Prompt.Input<string>("Login");
            teacher.Password = Prompt.Password("Password");
            teacher.RegistrationDate = DateTime.Now;

            var result = await teacherService.CreateAsync(teacher);

            if (result is false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccsesfully Created");
                Console.ForegroundColor = ConsoleColor.White;
            }
            await SubFooter.MakeFooterAsync();
        }
    }
}
