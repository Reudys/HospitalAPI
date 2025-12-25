using HospitalAPI.Models;

namespace HospitalAPI.Interfaces
{
    public interface ISpecializationService
    {
        Task<IEnumerable<Specialization>> GetAllAsync();
        Task<Specialization> CreateAsync(Specialization specialization);
    }
}
