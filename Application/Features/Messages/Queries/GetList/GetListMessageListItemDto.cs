namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageListItemDto
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public Guid CompanyId { get; set; }
    public string MessageContent { get; set; }
}