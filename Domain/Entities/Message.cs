using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Message : Entity<int>
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public string MessageContent { get; set; }


    public Message()
    {
        AppUser = new AppUser();
        Company = new Company();
        MessageContent = string.Empty;
    }

}