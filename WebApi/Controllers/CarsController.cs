using Application.Features.Car.Commands.Create;
using Application.Features.Car.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CarsController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand command)
    {
        var data = await Mediator.Send(command);
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var data = await Mediator.Send(new GetListCarQuery()
        {
            PageRequest = pageRequest
        });

        return Ok(data);
    }
}