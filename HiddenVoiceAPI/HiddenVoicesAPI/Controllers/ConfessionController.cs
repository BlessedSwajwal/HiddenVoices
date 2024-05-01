using Application.Confessions.Command.Create;
using Application.Confessions.Query.GetPagedConfessions;
using HiddenVoicesAPI.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HiddenVoicesAPI.Controllers;

[ApiController]
[Route("api/Confession")]
public class ConfessionController(ISender _mediator) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewConfession(CreateConfessionRequest request)
    {
        var command = new CreateConfessionCommand(request.title, request.message);
        var response = await _mediator.Send(command);

        return response.Match(
                confession =>
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(10)
                    };
                    Response.Cookies.Append(confession.Id.ToString(), confession.SecretKey, cookieOptions);
                    return Ok(confession);
                },
                error => Problem(statusCode: error.StatusCode, detail: error.ErrorMessage));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetPagedConfessions(int offset, int count)
    {
        var res = Request;
        var query = new GetPagedConfessionsQuery(offset, count);
        var response = await _mediator.Send(query);

        return response.Match(
            confessions => Ok(confessions),
            error => Problem(statusCode: error.StatusCode, detail: error.ErrorMessage)
            );
    }
}
