namespace OrderManagement.API
{
    public class PageParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? Sort { get; set; }
        public string? Filter { get; set; }
    }

}
