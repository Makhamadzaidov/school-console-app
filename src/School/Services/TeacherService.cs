using School.Interfaces.Repositories;
using School.Interfaces.ServiceInterfaces;
using School.Models;
using School.Repositories;
using School.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherService()
        {
            teacherRepository = new TeacherRepository();
        }

        public async Task<bool> CreateAsync(Teacher teacher)
        {
            var result = await teacherRepository.GetAsync(teacher.TeacherId);
            if (result is not null) return false;

            teacher.Password = ComputeSha256Hash(teacher.Password);
            await teacherRepository.CreateAsync(teacher);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, string login, string password)
        {
            var teacher = await teacherRepository.GetAsync(id);

            if (login == teacher.Login && ComputeSha256Hash(password) == teacher.Password)
            {
                await teacherRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TeacherViewModel>> GetAllAsync()
        {
            var teachers = await teacherRepository.GetAllAsync();
            ICollection<TeacherViewModel> list = new List<TeacherViewModel>();

            foreach (var teacher in teachers)
            {
                TeacherViewModel teacherViewModel = new TeacherViewModel();
                teacherViewModel.TeacherId = teacher.TeacherId;
                teacherViewModel.FirstName = teacher.FirstName;
                teacherViewModel.LastName = teacher.LastName;
                teacherViewModel.Age = teacher.Age;
                teacherViewModel.Gender = teacher.Gender;
                teacherViewModel.Subject = teacher.Subject;
                list.Add(teacherViewModel);
            }
            return list;
        }

        public async Task<TeacherViewModel> GetAsync(int id)
            => (await GetAllAsync()).FirstOrDefault(teacher => teacher.TeacherId == id);

        public async Task<bool> UpdateAsync(int id, string login, string password, Teacher teacher)
        {
            var dbTeacher = (await teacherRepository.GetAsync(id));

            if (login == dbTeacher.Login && ComputeSha256Hash(password) == dbTeacher.Password)
            {
                teacher.Password = ComputeSha256Hash(teacher.Password);
                await teacherRepository.UpdateAsync(id, teacher);
                return true;
            }
            return false;
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
