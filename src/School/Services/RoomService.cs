using School.Interfaces.Repositories;
using School.Interfaces.ServiceInterfaces;
using School.Models;
using School.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
        }

        public async Task<bool> CreateAsync(Room room)
        {
            var result = await roomRepository.GetAsync(room.RoomId);
            if (result is not null) return false;

            await roomRepository.CreateAsync(room);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
            => await roomRepository.DeleteAsync(id);

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await roomRepository.GetAllAsync();

        public async Task<Room> GetAsync(int id)
            => await roomRepository.GetAsync(id);

        public async Task UpdateAsync(int id, Room room)
            => await roomRepository.UpdateAsync(id, room);
    }
}
