using BsButtonApi.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BsButtonApi.Data.Mapping
{
    public class BsReasonCodeMap : IEntityTypeConfiguration<BsReasonCode>
    {
        public void Configure(EntityTypeBuilder<BsReasonCode> builder)
        {
            //Table Properties
            builder.HasKey(col => new {col.ReasonCodeId});
            builder.ToTable("BsReasonCode", "dbo");


            //Column Properties
            builder.Property(col => col.ReasonCodeId).ValueGeneratedOnAdd();
        }
    }
}