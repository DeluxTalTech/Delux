using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Delux.Aids;
using Delux.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Delux.Pages.Common
{
    public abstract class BasePageModel<TRepository, TDomain, TView> : PageModel
        where TRepository : ICrudMethods<TDomain>, ISorting, ISearching, IPaging
    {

        protected internal TRepository Db;

        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }

        public int PageIndex
        {
            get => Db.PageIndex;
            set => Db.PageIndex = value;
        }
        public int TotalPages => Db.TotalPages;
        public bool HasPreviousPage => Db.HasPreviousPage;
        public bool HasNextPage => Db.HasNextPage;

        public string SearchString
        {
            get => Db.SearchString;
            set => Db.SearchString = value;
        }

        public string SortOrder
        {
            get => Db.SortOrder;
            set => Db.SortOrder = value;
        }

        public abstract string PageLink { get; }

        protected internal BasePageModel(TRepository r)
        {
            Db = r;
        }

        [BindProperty]
        public TView Item { get; set; }
        public IList<TView> Items { get; set; }
        public abstract string ItemId { get; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        protected internal async Task<bool> AddItem()
        {
            if (!ModelState.IsValid) return false;
            await Db.Add(ToObject());

            return true;
        }

        protected internal abstract TDomain ToObject();

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        protected internal async Task<bool> UpdateItem()
        {
            if (!ModelState.IsValid) return false;
            await Db.Update(ToObject());

            return true;
        }

        protected internal async Task GetItem(string id)
        {
            var o = await Db.Get(id);
            Item = ToView(o);
        }

        protected internal abstract TView ToView(TDomain domain);

        protected internal async Task DeleteItem(string id)
        {
            await Db.Delete(id);
        }

        public string SortString<T>(Expression<Func<T, object>> ex)
        {
            var name = GetMember.Name(ex);
            string sortOrder;
            if (string.IsNullOrEmpty(SortOrder)) sortOrder = name;
            else if (!SortOrder.StartsWith(name)) sortOrder = name;
            else if (SortOrder.EndsWith("_desc")) sortOrder = name;
            else sortOrder = name + "_desc";

            return $"{PageLink}?sortOrder={sortOrder}&searchString={SearchString}";
        }

        protected internal async Task GetItems(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {

            if (searchString != null) { pageIndex = 1; }
            else { searchString = currentFilter; }

            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex ?? 1;
            var l = await Db.Get();
            Items = new List<TView>();
            foreach (var e in l) Items.Add(ToView(e));
        }

    }
}
