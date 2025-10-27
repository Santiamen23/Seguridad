using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Repositories
{

    public class HospitalRepository : IHospitalRepository
    {
        private readonly AppDbContext _db;
        public HospitalRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Hospital hospital)
        {
            await _db.Hospitals.AddAsync(hospital);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var hospital = await _db.Hospitals.FirstOrDefaultAsync(x => x.Id == id);
            if (hospital is null) return false;
            _db.Hospitals.Remove(hospital);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await _db.Hospitals.ToListAsync();
        }

        public async Task<Hospital?> GetOne(Guid id)
        {
            return await _db.Hospitals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Hospital>> GetType1And3()
        {
            return await _db.Hospitals.Where(h => h.Type == 1 || h.Type == 3).ToListAsync();
        }

        public async Task<Hospital> Update(Hospital hospital)
        {
            var updatedHospital =await _db.Hospitals.FirstOrDefaultAsync(h=>h.Id==hospital.Id);
            if(updatedHospital is null) return null;
            _db.Update(hospital);
            await _db.SaveChangesAsync();
            return hospital;
        }
    }
}
