using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Driver : Entity<int>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public Driver()
    {
        Name = string.Empty;
        SurName = string.Empty;
        Phone = string.Empty;
        Email = string.Empty;
        Company = new Company();
    }
    
    
}