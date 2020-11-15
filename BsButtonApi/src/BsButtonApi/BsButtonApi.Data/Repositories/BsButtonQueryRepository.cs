using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BsButtonApi.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BsButtonApi.Data.Repositories
{
    public class BsButtonQueryRepository
    {
        private BsContext Context { get; }
        public const string OtherValue = "Other";

        public BsButtonQueryRepository(BsContext bsContext)
        {
            Context = bsContext;
        }

        public async Task<List<TEntity>> GetList<TEntity>() where TEntity : class
        {
            var entityList = await Context.Set<TEntity>().AsNoTracking().ToListAsync();
            return entityList;
        }

        public async Task<BsReasonCode> GetReasonCodeAsync(string reportReasonCode)
        {
            var reasonCodeList = await GetList<BsReasonCode>();
            var reasonCode = reasonCodeList.FirstOrDefault(rsn => string.Equals(rsn.ReasonCode, reportReasonCode, StringComparison.CurrentCultureIgnoreCase)) ??
                             reasonCodeList.FirstOrDefault(rsn => string.Equals(rsn.ReasonCode, OtherValue, StringComparison.CurrentCultureIgnoreCase));
            return reasonCode;
        }

        public async Task<BsSocialMediaSource> GetSocialMediaSource(string reportedFrom)
        {
            var socialMediaSourceList = await GetList<BsSocialMediaSource>();
            var socialMediaSource = socialMediaSourceList.FirstOrDefault(soc => string.Equals(soc.SourceCodeName,reportedFrom , StringComparison.CurrentCultureIgnoreCase)) ??
                                        socialMediaSourceList.FirstOrDefault(soc => string.Equals(soc.SourceCodeName, OtherValue, StringComparison.CurrentCultureIgnoreCase));
            return socialMediaSource;
        }

    }
}