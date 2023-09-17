
using Domain.Enums;

namespace Application.Features.Transportations.Commands.Create;

public class CreatedTransportationResponse
{
    public TransportType TransportType { get; set; }
    public int AppUserId { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public DateTime TransportDate { get; set; }
}