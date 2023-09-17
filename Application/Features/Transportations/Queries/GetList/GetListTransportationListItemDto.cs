using Domain.Enums;

namespace Application.Features.Transportations.Queries.GetList;

public class GetListTransportationListItemDto
{
    public Guid Id { get; set; }
    public TransportType TransportType { get; set; }
    public int AppUserId { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public DateTime TransportDate { get; set; }
}