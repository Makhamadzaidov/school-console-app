using School.Models;
using School.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces.ServiceInterfaces
{
    public interface ITeacherService
    {
        Task<bool> CreateAsync(Teacher teacher);
        Task<TeacherViewModel> GetAsync(int id);
        Task<IEnumerable<TeacherViewModel>> GetAllAsync();
        Task<bool> UpdateAsync(int id, string login, string password, Teacher teacher);
        Task<bool> DeleteAsync(int id, string login, string password);
    }
}
