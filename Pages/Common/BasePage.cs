using System;
using System.Linq.Expressions;
using Delux.Aids;
using Delux.Domain.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Delux.Pages.Common
{

    public abstract class BasePage<TRepository, TDomain, TView, TData> : PageModel
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {

        protected TRepository Db;

        protected internal BasePage(TRepository r) => Db = r;

        public string SortOrder
        {
            get => Db.SortOrder;
            set => Db.SortOrder = value;
        }
        public string SearchString
        {
            get => Db.SearchString;
            set => Db.SearchString = value;
        }
        public string FixedValue
        {
            get => Db.FixedValue;
            set => Db.FixedValue = value;
        }
        public string FixedFilter
        {
            get => Db.FixedFilter;
            set => Db.FixedFilter = value;
        }

        protected internal void SetFixedFilter(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
        }

        protected internal abstract void SetPageValues(string sortOrder, string searchString, in int pageIndex);

        public string GetSortString(Expression<Func<TData, object>> e, string page)
        {
            var name = GetMember.Name(e);
            var sortOrder = GetSortOrder(name);

            return $"{page}?sortOrder={sortOrder}&currentFilter={SearchString}"
                   + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}";
        }

        internal string GetSortOrder(string name)
        {
            if (string.IsNullOrEmpty(SortOrder)) return name;
            if (!SortOrder.StartsWith(name)) return name;
            if (SortOrder.EndsWith("_desc")) return name;

            return name + "_desc";
        }

        internal static string GetSearchString(string currentFilter, string searchString, ref int? pageIndex)
        {
            if (searchString != null) { pageIndex = 1; }
            else { searchString = currentFilter; }

            return searchString;

        }

    }

}
