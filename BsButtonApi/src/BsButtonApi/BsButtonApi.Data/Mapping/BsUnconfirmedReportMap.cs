using BsButtonApi.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BsButtonApi.Data.Mapping
{
    public class BsUnconfirmedReportMap : IEntityTypeConfiguration<BsUnconfirmedReport>
    {
        public void Configure(EntityTypeBuilder<BsUnconfirmedReport> builder)
        {
            //Table Properties
            builder.HasKey(col => new {Id = col.UnconfirmedReportId});
            builder.ToTable("BsUnconfirmedReport", "dbo");

            //Column Properties
            builder.Property(col => col.UnconfirmedReportId).ValueGeneratedOnAdd();
        }
    }
}