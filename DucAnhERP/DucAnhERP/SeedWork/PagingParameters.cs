namespace DucAnhERP.SeedWork
{
    public class PagingParameters
    {
        const int maxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        public int pageSize { get; set; } = 10;

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set 
            { 
                pageSize = (value > maxPageSize) ? maxPageSize : value; 
            }
        }
    }
}
