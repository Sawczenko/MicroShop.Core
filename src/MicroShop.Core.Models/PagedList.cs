namespace MicroShop.Core.Models
{
    public class PagedList<T>
    {
        public PagedList() 
        {
            Items = new List<T>();
        }

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            if (pageSize > 0)
            {
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            }

            Items = items as IList<T> ?? new List<T>(items);
            TotalCount = count;
        }

        public IList<T> Items { get; }

        public int PageSize { get; set; }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool IsFirstPage => PageNumber == 0;

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

    public class PagedListDto<T>
    {

        public PagedListDto(IList<T> items, int pageSize, int pageNumber, int totalPages, bool isFirstPage, bool isLastPage, int count, int totalCount)
        {
            Items = items;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = totalPages;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;
            Count = count;
            TotalCount = totalCount;
        }

        public IList<T> Items { get; }

        public int PageSize { get; }

        public int PageNumber { get; }

        public int TotalPages { get; }

        public bool IsFirstPage { get; }

        public bool IsLastPage { get; }

        public int Count { get; }

        public int TotalCount { get; }

        public T this[int index] => Items[index];

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        public void Add(T item)
        {
            Items.Add(item);
        }
    }
}