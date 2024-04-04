using School.Models;
using School.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces.ServiceInterfaces
{
    public interface IPupilService
    {
        Task<bool> CreateAsync(Pupil pupil);
        Task<PupilViewModel> GetAsync(int id);
        Task<IEnumerable<PupilViewModel>> GetAllAsync();
        Task<bool> UpdateAsync(int id, string login, string password, Pupil pupil);
        Task<bool> DeleteAsync(int id, string login, string password);
    }
}
