using Microsoft.EntityFrameworkCore;

namespace BsButtonApi.Data.Mapping
{
    public class EntityMapper
    {
        public void Configure(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BsReasonMap());
            builder.ApplyConfiguration(new BsReasonCodeMap());
            builder.ApplyConfiguration(new BsSocialMediaSourceMap());
            builder.ApplyConfiguration(new BsSourceMap());
            builder.ApplyConfiguration(new BsUnconfirmedReportMap());
        }
    }


}
