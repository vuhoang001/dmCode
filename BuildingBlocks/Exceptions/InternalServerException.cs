namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException() : base("Lỗi hệ thống")
    {
    }
}