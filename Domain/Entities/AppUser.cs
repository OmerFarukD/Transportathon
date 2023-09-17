using Core.Persistence.Repositories;
using Core.Security.Entities;


namespace Domain.Entities;

public class AppUser :User
{
    public AppUser()
    {
        PhoneNumber = String.Empty;
        Transportations = new List<Transportation>();
        Reviews = new List<Review>();
    }
    
    public string PhoneNumber { get; set; }
    public   ICollection<Transportation> Transportations { get; set; }
    public  ICollection<Review> Reviews { get; set; }

}