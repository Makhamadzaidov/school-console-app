using System.Threading.Tasks;

namespace School.Interfaces.Common
{
    public interface ICreateable<T>
    {
        Task CreateAsync(T obj);
    }
}
