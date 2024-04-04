using ConsoleTables;
using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Models;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Rooms
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleTable roomtable = new ConsoleTable("Id", "Name", "Height", "Width");

            IRoomService roomService = new RoomService();
            var rooms = await roomService.GetAllAsync();

            foreach (var item in rooms)
                roomtable.AddRow(item.RoomId, item.Name, item.Height, item.Width);

            roomtable.Write();
            Console.ForegroundColor = ConsoleColor.White;

            Room room = new Room();
            room.RoomId = Prompt.Input<int>("Id");
            room.Name = Prompt.Input<string>("Name");
            room.Height = Prompt.Input<double>("Height");
            room.Width = Prompt.Input<double>("Width");

            await roomService.UpdateAsync(room.RoomId, room);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSuccessfully Updated");
            Console.ForegroundColor = ConsoleColor.White;
            await SubFooter.MakeFooterAsync();
        }
    }
}
