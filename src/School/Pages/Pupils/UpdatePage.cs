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
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable table = new ConsoleTable("Id", "Last Name", "First Name",
                "Age", "Class", "Gender", "Teacher Full Name", "Room Name");

            IPupilService pupilService = new PupilService();
            var pupils = await pupilService.GetAllAsync();

            foreach (var item in pupils)
            {
                table.AddRow(item.PupilId, item.LastName, item.FirstName,
                    item.Age, item.Class, item.Gender, item.TeacherFullName, item.RoomName);
            }
            table.Write();
            Console.ForegroundColor = ConsoleColor.White;

            Pupil pupil = new Pupil();
            pupil.PupilId = Prompt.Input<int>("Id");

            #region Teacher List
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
            #endregion

            pupil.RoomId = Prompt.Input<int>("Room Id");
            pupil.FirstName = Prompt.Input<string>("First Name");
            pupil.LastName = Prompt.Input<string>("Last Name");
            pupil.Class = Prompt.Input<int>("Class");
            pupil.Age = Prompt.Input<int>("Age");

            pupil.Age = Prompt.Input<int>("Age");
            Console.WriteLine("1. Male    2. Female");
            pupil.Gender = Prompt.Input<Gender>("Gender") - 1;
            pupil.Address = Prompt.Input<string>("Address");

            pupil.Login = Prompt.Input<string>("New Login");
            pupil.Password = Prompt.Password("New Password");

            var oldLogin = Prompt.Input<string>("Enter old Login");
            var oldPassword = Prompt.Password("Enter old Password");

            bool check = await pupilService.UpdateAsync(pupil.PupilId, oldLogin, oldPassword, pupil);

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
