namespace Application.Features.Messages.Commands.Create;

public class CreatedMessageResponse
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public Guid CompanyId { get; set; }
    public string MessageContent { get; set; }
}