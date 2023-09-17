using Application.Features.Drivers.Commands.Create;
using Application.Features.Drivers.Queries.GetById;
using Application.Features.Drivers.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DriversController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDriverCommand command)
    {
        var data = await Mediator.Send(command);
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDriverQuery query = new()
        {
            PageRequest = pageRequest
        };

        var data = await Mediator.Send(query);

        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        GetByIdDriverQuery query = new()
        {
            Id = id
        };

        var data = await Mediator.Send(query);

        return Ok(data);
    }
    
}