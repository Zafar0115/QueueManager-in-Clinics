using Microsoft.EntityFrameworkCore;

namespace QueueManager.Application.Models
{
    public class PaginatedList<T>
    {
        public IQueryable<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginatedList(IQueryable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
