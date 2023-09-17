using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MessagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MessageCreateDto messageCreateDto)
    {
        CreateMessageCommand command = new()
        {
            MessageCreateDto = messageCreateDto,
            AppUserId = GetUserIdFromRequest()
        };

        var data = await Mediator.Send(command);

        data.AppUserId = GetUserIdFromRequest();
        return Ok(data);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMessageQuery query = new()
        {
            PageRequest = pageRequest
        };

        var data = await Mediator.Send(query);
        return Ok(data);
    }

}