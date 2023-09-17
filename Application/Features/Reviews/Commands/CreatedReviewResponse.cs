namespace Application.Features.Reviews.Commands;

public class CreatedReviewResponse
{
    public int AppUserId { get; set; }
    public int Point { get; set; }
    public string Comment { get; set; }

    public Guid CompanyId { get; set; }
}