namespace Catalog.API.Exceptions;

public class ApiNotFoundException : Exception
{
    public ApiNotFoundException() : base("Không tìm thấy dữ liệu")
    {
    }
}