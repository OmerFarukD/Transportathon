namespace Application.Features.Companies.Commands.Create;

public class CreatedCompanyResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}