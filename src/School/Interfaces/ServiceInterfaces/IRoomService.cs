using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<bool> CreateAsync(Room room);
        Task<Room> GetAsync(int id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task UpdateAsync(int id, Room room);
        Task<bool> DeleteAsync(int id);
    }
}
