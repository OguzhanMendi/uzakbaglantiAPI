using Microsoft.EntityFrameworkCore;
using uzakbaglantiAPI.Entities;

namespace uzakbaglantiAPI.Context
{
    public class uzakContext:DbContext
    {
        public uzakContext(DbContextOptions<uzakContext> opt) : base(opt)
        {
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public DbSet<Kullanici> kullanici { get; set; }

        public DbSet<Baglanti> Baglanti { get; set; }
    }
}
