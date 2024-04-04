using Newtonsoft.Json;
using School.Constants;
using School.Interfaces.Repositories;
using School.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace School.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly string dbPath = DatabaseConstants.TEACHER_DB_PATH;

        public async Task CreateAsync(Teacher obj)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var teachers = JsonConvert.DeserializeObject<ICollection<Teacher>>(json);
            teachers.Add(obj);

            json = JsonConvert.SerializeObject(teachers, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var teachers = JsonConvert.DeserializeObject<IList<Teacher>>(json);
            var item = teachers.FirstOrDefault(teacher => teacher.TeacherId == id);

            if (item is null)
                return false;

            teachers.Remove(item);
            json = JsonConvert.SerializeObject(teachers, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
            return true;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(dbPath);
            return JsonConvert.DeserializeObject<IEnumerable<Teacher>>(json);
        }

        public async Task<Teacher> GetAsync(int id)
            => (await GetAllAsync()).FirstOrDefault(teacher => teacher.TeacherId == id);

        public async Task UpdateAsync(int id, Teacher obj)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var teachers = JsonConvert.DeserializeObject<IList<Teacher>>(json);

            var index = teachers.TakeWhile(teacher => teacher.TeacherId != id).Count();
            teachers[index] = obj;

            json = JsonConvert.SerializeObject(teachers, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
        }
    }
}
