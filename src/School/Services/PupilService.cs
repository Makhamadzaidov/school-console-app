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
    public class PupilService : IPupilService
    {
        private readonly IPupilRepository pupilRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IRoomRepository roomRepository;

        public PupilService()
        {
            pupilRepository = new PupilRepository();
            teacherRepository = new TeacherRepository();
            roomRepository = new RoomRepository();
        }

        public async Task<bool> CreateAsync(Pupil pupil)
        {
            var result = await pupilRepository.GetAsync(pupil.PupilId);
            if (result is not null) return false;

            pupil.Password = ComputeSha256Hash(pupil.Password);
            await pupilRepository.CreateAsync(pupil);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, string login, string password)
        {
            var pupil = await pupilRepository.GetAsync(id);

            if (pupil.Login == login && pupil.Password == password)
            {
                await pupilRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<PupilViewModel>> GetAllAsync()
        {
            var pupils = await pupilRepository.GetAllAsync();
            ICollection<PupilViewModel> result = new List<PupilViewModel>();

            foreach (var pupil in pupils)
            {
                PupilViewModel pupilViewModel = new PupilViewModel();
                pupilViewModel.PupilId = pupil.PupilId;
                pupilViewModel.LastName = pupil.LastName;
                pupilViewModel.FirstName = pupil.FirstName;

                var teacher = await teacherRepository.GetAsync(pupil.TeacherId);
                pupilViewModel.TeacherFullName = teacher.LastName + " " + teacher.FirstName;

                var room = await roomRepository.GetAsync(pupil.RoomId);
                pupilViewModel.RoomName = room.Name;

                pupilViewModel.Age = pupil.Age;
                pupilViewModel.Class = pupil.Class;
                pupilViewModel.Gender = pupil.Gender;
                result.Add(pupilViewModel);
            }
            return result;
        }

        public async Task<PupilViewModel> GetAsync(int id)
            => (await GetAllAsync()).FirstOrDefault(pupil => pupil.PupilId == id);

        public async Task<bool> UpdateAsync(int id, string login, string password, Pupil pupil)
        {
            var dbPupil = (await pupilRepository.GetAsync(id));

            if (dbPupil.Login == login && dbPupil.Password == password)
            {
                pupil.Password = ComputeSha256Hash(password);
                await pupilRepository.UpdateAsync(id, pupil);
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
