using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Services;
using System;
using System.Threading.Tasks;

namespace School.Pages.Rooms
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable roomtable = new ConsoleTable("Id", "Name", "Height", "Width");

            IRoomService roomService = new RoomService();
            var rooms = await roomService.GetAllAsync();

            foreach (var room in rooms)
                roomtable.AddRow(room.RoomId, room.Name, room.Height, room.Width);

            roomtable.Write();
            Console.ForegroundColor = ConsoleColor.White;
            await SubFooter.MakeFooterAsync();
        }
    }
}
