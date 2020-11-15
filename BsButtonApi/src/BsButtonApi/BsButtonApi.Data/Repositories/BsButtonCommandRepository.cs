using System;
using System.Threading.Tasks;
using BsButtonApi.Data.ResultModels;

namespace BsButtonApi.Data.Repositories
{
    public class BsButtonCommandRepository
    {
        private BsContext Context { get; }

        public BsButtonCommandRepository(BsContext bsContext)
        {
            Context = bsContext;
        }

        public async Task<MethodResultValue<TEntity>> Add<TEntity>(TEntity entity) where TEntity : class
        {
            var result = new MethodResultValue<TEntity>();
            try
            {
                var addResult = await Context.Set<TEntity>().AddAsync(entity);
                result.ReturnValue = addResult.Entity;
                return result;
            }
            catch (Exception ex)
            {
                result.AddErrorMessage(ex.Message);
                return result;
            }
        }

        public async Task<MethodResultValue<int>> SaveChangesAsync()
        {
            var result = new MethodResultValue<int>();
            result.ReturnValue = await Context.SaveChangesAsync();
            return result;
        }
    }
}