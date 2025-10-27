using Security.Models;

namespace Security.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAll();
        Task<Hospital> GetOne(Guid id);
        Task Add(Hospital hospital);

        Task<bool> Delete(Guid id);

        Task<Hospital> Update(Hospital hospital);

        Task<IEnumerable<Hospital>> GetType1And3();
    }
}
