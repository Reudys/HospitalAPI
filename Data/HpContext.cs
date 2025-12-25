using Microsoft.EntityFrameworkCore;
using HospitalAPI.Models;

namespace HospitalAPI.Data
{
    public class HpContext : DbContext
    {
        public HpContext(DbContextOptions<HpContext> options) : base(options)
        {
        }

        public DbSet<Specialization> Specializations { get; set; }
    }
}
