using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Transportation :Entity<Guid>
{

    public TransportType TransportType { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public ReservationStatus ReservationStatus { get; set; }
    public DateTime TransportDate { get; set; }

    public ICollection<Message> Messages { get; set; }

    public Transportation()
    {
        AppUser = new AppUser();
        Messages = new List<Message>();
    }
    
}