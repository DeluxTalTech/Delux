namespace Delux.Domain.Common
{
    public interface IPaging
    {
        int PageSize { get; set; }
        int PageIndex { get; set; }
        int TotalPages { get; }
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
    }
}
