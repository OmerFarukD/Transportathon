using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CompaniesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCompanyCommand command)
    {
        var data = await Mediator.Send(command);
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyQuery query = new()
        {
            PageRequest = pageRequest
        };

        var data = await Mediator.Send(query);

        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        GetByIdCompanyQuery query = new()
        {
            Id = id
        };
        
        var data = await Mediator.Send(query);
        return Ok(data);
    }


}