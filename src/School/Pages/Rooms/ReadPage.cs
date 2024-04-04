using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Rooms
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            IRoomService roomService = new RoomService();

            ConsoleTable roomtable = new ConsoleTable("Id", "Name", "Height", "Width");
            int id = Prompt.Input<int>("Id");
            var room = await roomService.GetAsync(id);

            roomtable.AddRow(room.RoomId, room.Name, room.Height, room.Width);
            roomtable.Write();
            await SubFooter.MakeFooterAsync();
        }
    }
}
