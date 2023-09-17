using Domain.Enums;

namespace Application.Features.Car.Queries.GetList;

public class GetListCarItemDto
{
    public int Id { get; set; }
    public CarType CarType { get; set; }
    public string CarDetail { get; set; }
    public string Plate { get; set; }
    public string CompanyName { get; set; }
}