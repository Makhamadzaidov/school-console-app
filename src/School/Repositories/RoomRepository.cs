using Newtonsoft.Json;
using School.Constants;
using School.Interfaces.Repositories;
using School.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace School.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly string dbPath = DatabaseConstants.ROOM_DB_PATH;

        public async Task CreateAsync(Room obj)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var rooms = JsonConvert.DeserializeObject<ICollection<Room>>(json);
            rooms.Add(obj);

            json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var rooms = JsonConvert.DeserializeObject<ICollection<Room>>(json);

            var item = rooms.FirstOrDefault(room => room.RoomId == id);
            if (item is null)
                return false;

            rooms.Remove(item);
            json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
            return true;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(dbPath);
            return JsonConvert.DeserializeObject<IEnumerable<Room>>(json);
        }

        public async Task<Room> GetAsync(int id)
            => (await GetAllAsync()).FirstOrDefault(room => room.RoomId == id);

        public async Task UpdateAsync(int id, Room obj)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var rooms = JsonConvert.DeserializeObject<IList<Room>>(json);

            var index = rooms.TakeWhile(room => room.RoomId != id).Count();
            rooms[index] = obj;

            json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
        }
    }
}
