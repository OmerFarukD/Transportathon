using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Review : Entity<Guid>
{
    public int Point { get; set; }
    public string Comment { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Review()
    {
        Comment = string.Empty;
        Company = new Company();
        AppUser = new AppUser();
    }
}