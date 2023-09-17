namespace Application.Features.Reviews.Queries.GetList;

public class GetListReviewListItemDto
{
    public int AppUserId { get; set; }
    public int Point { get; set; }
    public string Comment { get; set; }
    public Guid CompanyId { get; set; }
}