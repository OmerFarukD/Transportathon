namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}