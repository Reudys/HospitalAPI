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

        public async Task<Specialization> UpdateAsync(int id, Specialization specialization)
        {
            var special = _context.Specializations.Find(id);
            if (special == null) return null;
            special.Name = specialization.Name;
            special.Description = specialization.Description;
            await _context.SaveChangesAsync();
            return special;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var special = _context.Specializations.Find(id);
            if (special == null) return false;
            _context.Specializations.Remove(special);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
