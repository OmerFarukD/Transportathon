using Application.Features.Transportations.Commands.Create;
using Application.Features.Transportations.Queries.GetList;
using Core.Application.Requests;
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

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTransportationQuery query = new()
        {
            PageRequest = pageRequest
        };

        var response = await Mediator.Send(query);

        return Ok(response);

    }

}