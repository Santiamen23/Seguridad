using Security.Models;
using Security.Models.DTOS;
using Security.Repositories;

namespace Security.Services
{

    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repo;
        public HospitalService(IHospitalRepository repo)
        {
            _repo = repo;
        }
        public async Task<Hospital> CreateHospital(CreateHospitalDto dto)
        {
            var hospital = new Hospital
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                Type = dto.Type
            };
            await _repo.Add(hospital);
            return hospital;
        }

        public async Task<bool> DeleteHospital(Guid id)
        {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Hospital> GetOne(Guid id)
        {
            return await _repo.GetOne(id);
        }

        public async Task<IEnumerable<Hospital>> GetType1And3()
        {
            return await _repo.GetType1And3();
        }

        public async Task<Hospital> Update(Guid id, UpdateHospitalDto dto)
        {
            var hospitalFromDb = await _repo.GetOne(id);

            if (hospitalFromDb == null)return null;            
            hospitalFromDb.Name = dto.Name;
            hospitalFromDb.Address = dto.Address;
            hospitalFromDb.Type = dto.Type;
            await _repo.Update(hospitalFromDb);
            return hospitalFromDb;

        }
    }
}
