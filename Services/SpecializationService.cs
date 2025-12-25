using HospitalAPI.Data;
using HospitalAPI.Interfaces;
using HospitalAPI.Models;

namespace HospitalAPI.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly HpContext _context;

        public SpecializationService(HpContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            return await Task.FromResult(_context.Specializations.ToList());
        }

        public async Task<Specialization> CreateAsync(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync();
            return specialization;
        }
    }
}
