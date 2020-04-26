using System.Threading.Tasks;
using Delux.Data.Common;
using Delux.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Common
{
    public abstract class IdRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TData : IdData, new()
        where TDomain : Entity<TData>, new()
    {

        protected IdRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected override async Task<TData> GetData(string id)
            => await DbSet.FirstOrDefaultAsync(m => m.Id == id);

        protected override string GetId(TDomain entity) => entity?.Data?.Id;

    }
}