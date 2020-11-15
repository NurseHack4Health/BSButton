using BsButtonApi.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BsButtonApi.Data.Mapping
{
    public class BsSourceMap : IEntityTypeConfiguration<BsSource>
    {
        public void Configure(EntityTypeBuilder<BsSource> builder)
        {
            //Table Properties
            builder.HasKey(col => new {col.SourceId});
            builder.ToTable("BsSource", "dbo");

            //Column Properties
            builder.Property(col => col.SourceId).ValueGeneratedOnAdd();
        }
    }
}