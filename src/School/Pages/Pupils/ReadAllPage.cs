using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using System;
using System.Threading.Tasks;

namespace School.Pages.Pupils
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable table = new ConsoleTable("Id", "Last Name", "First Name",
                "Age", "Class", "Gender", "Teacher Full Name", "Room Name");

            IPupilService pupilService = new PupilService();
            var pupils = await pupilService.GetAllAsync();

            foreach (var pupil in pupils)
            {
                table.AddRow(pupil.PupilId, pupil.LastName, pupil.FirstName,
                    pupil.Age, pupil.Class, pupil.Gender, pupil.TeacherFullName, pupil.RoomName);
            }
            table.Write();
            Console.ForegroundColor = ConsoleColor.White;
            await SubFooter.MakeFooterAsync();
        }
    }
}
