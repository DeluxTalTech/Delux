using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delux.Domain.Common;

namespace Delux.Pages.Common
{

    public abstract class PaginatedPage<TRepository, TDomain, TView, TData> :
        CrudPage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {

        protected PaginatedPage(TRepository r) : base(r) { }

        public IList<TView> Items { get; private set; }

        //public string SelectedId
        //{
        //    get;
        //    set;
        //}
        public int PageIndex
        {
            get => Db.PageIndex;
            set => Db.PageIndex = value;
        }
        public bool HasPreviousPage => Db.HasPreviousPage;
        public bool HasNextPage => Db.HasNextPage;

        public int TotalPages => Db.TotalPages;

        protected internal override void SetPageValues(string sortOrder, string searchString, in int pageIndex)
        {
            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex;
        }

        protected internal async Task GetList(string sortOrder, string currentFilter, string searchString,
            int? pageIndex, string fixedFilter, string fixedValue)
        {

            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = GetSearchString(currentFilter, searchString, ref pageIndex);
            PageIndex = pageIndex ?? 1;
            Items = await GetList();
        }

        internal async Task<List<TView>> GetList()
        {
            var l = await Db.Get();

            return l.Select(ToView).ToList();
        }

    }

}