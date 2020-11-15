using BsButtonApi.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BsButtonApi.Data.Mapping
{
    public class BsSocialMediaSourceMap : IEntityTypeConfiguration<BsSocialMediaSource>
    {
        public void Configure(EntityTypeBuilder<BsSocialMediaSource> builder)
        {
            //Table Properties
            builder.HasKey(col => new {col.SourceCodeId});
            builder.ToTable("BsSocialMediaSource", "dbo");

            //Column Properties
            builder.Property(col => col.SourceCodeId).ValueGeneratedOnAdd();
        }
    }
}