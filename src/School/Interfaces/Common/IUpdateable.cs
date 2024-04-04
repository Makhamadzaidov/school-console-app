using System.Threading.Tasks;

namespace School.Interfaces.Common
{
    public interface IUpdateable<T>
    {
        Task UpdateAsync(int id, T obj);
    }
}
