namespace Application.Features.Messages.Commands.Create;

public class MessageCreateDto
{
    public Guid CompanyId { get; set; }
    public string MessageContent { get; set; }
}