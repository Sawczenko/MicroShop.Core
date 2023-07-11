namespace MicroShop.Core.Models
{
    public class PagedList<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items as IList<T> ?? new List<T>(items);
            TotalCount = count;
        }

        public IList<T> Items { get; }

        public int PageSize { get; set; }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool IsFirstPage => PageNumber == 1;

        public bool IsLastPage => PageNumber == TotalPages;

        public int Count => Items.Count;

        public int TotalCount { get; set; }

        public T this[int index] => Items[index];

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        public void Add(T item)
        {
            Items.Add(item);
        }
    }
}