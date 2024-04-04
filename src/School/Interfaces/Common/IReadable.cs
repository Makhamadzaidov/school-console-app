using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces.Common
{
    public interface IReadable<T>
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
