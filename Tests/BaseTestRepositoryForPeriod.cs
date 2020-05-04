using System.Collections.Generic;
using System.Threading.Tasks;
using Delux.Data.Common;
using Delux.Domain.Common;

namespace Delux.Tests
{
    internal abstract class BaseTestRepositoryForPeriod<TObj, TData>
        where TObj : Entity<TData>
        where TData : PeriodData, new()
    {
        protected internal readonly List<TObj> List;
        public BaseTestRepositoryForPeriod()
        {
            List = new List<TObj>();
        }

        public async Task<List<TObj>> Get()
        {
            await Task.CompletedTask;
            return List;
        }

        public async Task<TObj> Get(string id)
        {
            await Task.CompletedTask;
            return List.Find(x => IsThis(x, id));
        }

        protected abstract bool IsThis(TObj entity, string id);

        public async Task Delete(string id)
        {
            await Task.CompletedTask;
            var obj = List.Find(x => IsThis(x, id));
            List.Remove(obj);
        }

        public async Task Add(TObj obj)
        {
            await Task.CompletedTask;
            List.Add(obj);
        }

        public async Task Update(TObj obj)
        {
            await Delete(GetId(obj));
            List.Add(obj);
        }

        protected abstract string GetId(TObj entity);

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }
    }

}
