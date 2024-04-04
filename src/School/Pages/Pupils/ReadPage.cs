using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Pupils
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable table = new ConsoleTable("Id", "Last Name", "First Name",
                "Age", "Class", "Gender", "Teacher Full Name", "Room Name");

            IPupilService pupilService = new PupilService();

            int id = Prompt.Input<int>("Id");
            var pupil = await pupilService.GetAsync(id);

            table.AddRow(pupil.PupilId, pupil.LastName, pupil.FirstName, pupil.Age,
                pupil.Class, pupil.Gender, pupil.TeacherFullName, pupil.RoomName);

            table.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
