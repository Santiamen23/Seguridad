using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetAll();
        Task<Hospital> GetOne(Guid id);
        Task<Hospital> CreateHospital(CreateHospitalDto dto);
        Task<bool> DeleteHospital(Guid id);
        Task<Hospital> Update(Guid id, UpdateHospitalDto dto);
        Task<IEnumerable<Hospital>> GetType1And3();
    }
}
