namespace Shared.Pagination;

public class PaginatedResult<TEntity> (int pageNumber, int pageSize, int totalItemCount, IEnumerable<TEntity> items)
{
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalItemCount { get; } = totalItemCount;
    public IEnumerable<TEntity> Items { get; } = items;
}