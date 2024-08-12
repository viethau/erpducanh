namespace DucAnhERP.Services
{
    public interface ISortService
    {
        List<T> SortTable<T>(List<T> listData, string columnName);

        string GetSortStyle(string columnName);
    }
}
