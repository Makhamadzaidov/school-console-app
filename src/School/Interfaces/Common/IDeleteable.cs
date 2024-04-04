using System.Threading.Tasks;

namespace School.Interfaces.Common
{
    public interface IDeleteable<T>
    {
        Task<bool> DeleteAsync(int id);
    }
}
