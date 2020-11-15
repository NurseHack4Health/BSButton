using System;
using BsButtonApi.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BsButtonApi.Data.Mapping
{
    public class BsReasonMap : IEntityTypeConfiguration<BsReason>
    {
        public void Configure(EntityTypeBuilder<BsReason> builder)
        {
            //Table Properties
            builder.HasKey(col => new {col.ReasonId});
            builder.ToTable("BsReason", "dbo");

            //Column Properties
            builder.Property(col => col.ReasonId).ValueGeneratedOnAdd();

        }
    }
}