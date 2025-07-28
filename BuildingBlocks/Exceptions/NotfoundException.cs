namespace BuildingBlocks.Exceptions;

public class NotfoundException : Exception
{
    public NotfoundException() : base("Không tìm thấy bản ghi")
    {
    }
}