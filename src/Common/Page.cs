namespace CarRentalManagement.Common;

public class Page<T>
{
    public Page()
    {
        PageNumber = 1;
        PageSize = 10;
        TotalPages = 1;
        TotalRecords = 0;
        Data = new List<T>();
    }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public List<T> Data { get; set; }
}