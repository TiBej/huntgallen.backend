using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class HgContext : DbContext
    {
        public HgContext(DbContextOptions<HgContext> options) : base(options)
        {
        }   
        
        public DbSet<History> Histories { get; set; }
        public DbSet<QR> QRs { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}