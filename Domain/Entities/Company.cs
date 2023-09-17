using Core.Persistence.Repositories;

namespace Domain.Entities;

public  class Company : Entity<Guid>
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public  ICollection<Car> Cars { get; set; }

    public Company()
    {
        Name=string.Empty;
        Address = string.Empty;
        PhoneNumber = string.Empty;
        Email = string.Empty;
        Cars = new List<Car>();
    }
    
    
}