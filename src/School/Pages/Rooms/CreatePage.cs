using School.Common;
using School.Interfaces.ServiceInterfaces;
using School.Models;
using School.Services;
using Sharprompt;
using System;
using System.Threading.Tasks;

namespace School.Pages.Rooms
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            IRoomService roomService = new RoomService();
            Room room = new Room();

            room.RoomId = Prompt.Input<int>("Id");
            room.Name = Prompt.Input<string>("Name");
            room.Height = Prompt.Input<double>("Height");
            room.Width = Prompt.Input<double>("Width");

            var result = await roomService.CreateAsync(room);
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
