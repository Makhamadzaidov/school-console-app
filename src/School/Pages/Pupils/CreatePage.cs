using ConsoleTables;
using School.Common;
using School.Enums;
using School.Interfaces.ServiceInterfaces;
using School.Models;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Pupils
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            IPupilService pupilService = new PupilService();
            Pupil pupil = new Pupil();

            #region Pupil List
            pupil.PupilId = Prompt.Input<int>("Id");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable teachertable = new ConsoleTable("Id", "Full Name", "Age", "Gender", "Subject");

            ITeacherService teacherService = new TeacherService();
            var teachers = await teacherService.GetAllAsync();

            foreach (var teacher in teachers)
                teachertable.AddRow(teacher.TeacherId, teacher.LastName + " " + teacher.FirstName,
                    teacher.Age, teacher.Gender, teacher.Subject);
            teachertable.Write();
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            pupil.TeacherId = Prompt.Input<int>("Teacher Id");

            #region Room List
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable roomtable = new ConsoleTable("Id", "Name", "Height", "Width");

            IRoomService roomService = new RoomService();
            var rooms = await roomService.GetAllAsync();

            foreach (var room in rooms)
                roomtable.AddRow(room.RoomId, room.Name, room.Height, room.Width);

            roomtable.Write();
            Console.ForegroundColor = ConsoleColor.White;
            pupil.RoomId = Prompt.Input<int>("RoomId");
            #endregion

            pupil.FirstName = Prompt.Input<string>("First Name");
            pupil.LastName = Prompt.Input<string>("Last Name");
            pupil.Class = Prompt.Input<int>("Class");
            pupil.Age = Prompt.Input<int>("Age");

            Console.WriteLine("1. Male    2. Female");
            pupil.Gender = Prompt.Input<Gender>("Gender") - 1;
            pupil.Address = Prompt.Input<string>("Address");
            pupil.Login = Prompt.Input<string>("Login");
            pupil.Password = Prompt.Password("Password");
            pupil.RegistrationDate = DateTime.Now;

            var result = await pupilService.CreateAsync(pupil);

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
