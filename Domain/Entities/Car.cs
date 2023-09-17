using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity<int>
{
    public CarType CarType { get; set; }
    public string CarDetail { get; set; }
    public string Plate { get; set; }

    public Guid CompanyId { get; set; }
    public  Company Company { get; set; }

    public Car()
    {
        CarDetail = string.Empty;
        Plate = string.Empty;
        Company = new Company();
    }
}