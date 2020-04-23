using Delux.Data.Common;

namespace Delux.Domain.Common
{
    public abstract class Entity<TData> where TData : NameData, new()
    {
        protected internal Entity(TData d = null) => Data = d;
        public TData Data { get; internal set; }
    }
}
