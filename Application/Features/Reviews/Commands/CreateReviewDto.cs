namespace Application.Features.Reviews.Commands;

public class CreateReviewDto
{
    public int Point { get; set; }
    public string Comment { get; set; }

    public Guid CompanyId { get; set; }
}