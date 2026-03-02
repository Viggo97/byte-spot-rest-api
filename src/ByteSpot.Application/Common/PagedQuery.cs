namespace ByteSpot.Application.Common;

public record PagedQuery
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 20;
    public int PageNumber { get; private init; } = DefaultPageNumber;
    public int PageSize { get; private init; } = DefaultPageSize;

    public PagedQuery()
    {
    }
    
    protected PagedQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize =  pageSize;
    }
}