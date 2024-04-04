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
    public class PupilRepository : IPupilRepository
    {
        private readonly string dbPath = DatabaseConstants.PUPIL_DB_PATH;

        public async Task CreateAsync(Pupil obj)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var pupils = JsonConvert.DeserializeObject<ICollection<Pupil>>(json);
            pupils.Add(obj);

            json = JsonConvert.SerializeObject(pupils, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var pupils = JsonConvert.DeserializeObject<ICollection<Pupil>>(json);
            var item = pupils.FirstOrDefault(pupil => pupil.PupilId == id);

            if (item is null)
                return false;
            pupils.Remove(item);
            json = JsonConvert.SerializeObject(pupils, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
            return true;
        }

        public async Task<IEnumerable<Pupil>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(dbPath);
            return JsonConvert.DeserializeObject<IEnumerable<Pupil>>(json);
        }

        public async Task<Pupil> GetAsync(int id)
            => (await GetAllAsync()).FirstOrDefault(pupil => pupil.PupilId == id);

        public async Task UpdateAsync(int id, Pupil obj)
        {
            string json = await File.ReadAllTextAsync(dbPath);
            var pupils = JsonConvert.DeserializeObject<IList<Pupil>>(json);

            var index = pupils.TakeWhile(pupil => pupil.PupilId != id).Count();
            pupils[index] = obj;

            json = JsonConvert.SerializeObject(pupils, Formatting.Indented);
            await File.WriteAllTextAsync(dbPath, json);
        }
    }
}
