namespace DucAnhERP.Services
{
    public class SortService : ISortService
    {

        //We need a field to tell us which direction
        //the table is currently sorted by
        private bool IsSortedAscending;

        //We also need a field to tell us which column the table is sorted by.
        private string CurrentSortColumn;
        public string GetSortStyle(string columnName)
        {
            if (CurrentSortColumn != columnName)
            {
                return "both";
            }
            if (IsSortedAscending)
            {
                return "up";
            }
            else
            {
                return "down";
            }
        }

        public List<T> SortTable<T>(List<T> listData, string columnName)
        {
            ArgumentNullException.ThrowIfNull(listData);

            // Nếu cột truyền vào khác với cột đang sort
            if (columnName != CurrentSortColumn)
            {
                // Gán thứ tự sắp xếp mặc định cho cột mới là tăng dần
                // Gán cột đang sắp xếp là cột truyền vào
                listData = listData.OrderBy(x =>
                                        x.GetType()
                                        .GetProperty(columnName)
                                        .GetValue(x, null))
                              .ToList();
                CurrentSortColumn = columnName;
                IsSortedAscending = true;

            }
            else // Nếu cột truyền vào là cột đang được sortSystem.NullReferenceException: 'Object reference not set to an instance of an object.'
            {
                if (IsSortedAscending)
                {
                    listData = listData.OrderByDescending(x =>
                                                      x.GetType()
                                                       .GetProperty(columnName)
                                                       .GetValue(x, null))
                                 .ToList();
                }
                else
                {
                    listData = listData.OrderBy(x =>
                                            x.GetType()
                                             .GetProperty(columnName)
                                             .GetValue(x, null))
                                             .ToList();
                }

                //Đảo giá trị thứ tự sắp xếp
                IsSortedAscending = !IsSortedAscending;
            }

            return listData;
        }

    }
}
