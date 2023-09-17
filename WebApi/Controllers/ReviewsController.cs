using Application.Features.Reviews.Commands;
using Application.Features.Reviews.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReviewsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReviewDto createReviewDto)
    {
        CreateReviewCommand command = new()
        {
            CreateReviewDto = createReviewDto,
            AppUserId = GetUserIdFromRequest()
        };

        var data = await Mediator.Send(command);
        data.AppUserId = GetUserIdFromRequest();
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReviewQuery query = new()
        {
            PageRequest = pageRequest
        };

        var data = await Mediator.Send(query);
        return Ok(data);
    }
}