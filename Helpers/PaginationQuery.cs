namespace api.Helpers
{
    public class PaginationQuery
    {
        private const int DefaultPageSize = 10;
        private const int MaxPageSize = 50;
        private int _pageSize = DefaultPageSize;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value <= 0)
                {
                    _pageSize = DefaultPageSize;
                    return;
                }

                _pageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
    }
}
