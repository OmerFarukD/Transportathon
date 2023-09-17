using Domain.Enums;

namespace Application.Features.Car.Commands.Create;

public class CreatedCarResponse
{
    public CarType CarType { get; set; }
    public string CarDetail { get; set; }
    public string Plate { get; set; }

    public Guid CompanyId { get; set; }
}