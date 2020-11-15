using BsButtonApi.Data.EntityModels;
using BsButtonApi.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BsButtonApi.Data
{
    public class BsContext : DbContext
    {
        public BsContext(DbContextOptions<BsContext> options) : base(options)
        {
        }

        public DbSet<BsReason> Reasons { get; set; }

        public DbSet<BsReasonCode> ReasonCodes { get; set; }

        public DbSet<BsSocialMediaSource> SocialMediaSources { get; set; }

        public DbSet<BsSource> Sources { get; set; }

        public DbSet<BsUnconfirmedReport> UnconfirmedReports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var mapper = new EntityMapper();
            mapper.Configure(builder);
            base.OnModelCreating(builder);
        }

    }
}