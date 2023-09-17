using Application.Features.Transportations.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransportationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTransportationDto createTransportationDto)
    {
        CreateTransportationCommand command = new()
        {
            TransportationDto = createTransportationDto,
            AppUserId = GetUserIdFromRequest()
        };

        var data = await Mediator.Send(command);
        data.AppUserId = GetUserIdFromRequest();
        return Ok(data);
    }
    
    
}