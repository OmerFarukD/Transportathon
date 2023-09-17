using Domain.Enums;

namespace Application.Features.Transportations.Commands.Create;

public class CreateTransportationDto
{
    public TransportType TransportType { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public DateTime TransportDate { get; set; }
}