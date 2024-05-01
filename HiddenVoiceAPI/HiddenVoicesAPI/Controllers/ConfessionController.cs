﻿using Application.Confessions.Command.Create;
using Application.Confessions.Query.ConfessionDetail;
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

                    return Ok(confession);
                },
                error => Problem(statusCode: error.StatusCode, detail: error.ErrorMessage));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetPagedConfessions(int offset, int count)
    {
        var query = new GetPagedConfessionsQuery(offset, count);
        var response = await _mediator.Send(query);

        return response.Match(
            confessions => Ok(confessions),
            error => Problem(statusCode: error.StatusCode, detail: error.ErrorMessage)
            );
    }

    [HttpGet("Detail")]
    public async Task<IActionResult> GetConfessionDetail([FromQuery] Guid confessionId)
    {
        var query = new GetConfessionDetailQuery(confessionId);
        var response = await _mediator.Send(query);

        return response.Match(
            confession => Ok(confession),
            error => Problem(statusCode: error.StatusCode, detail: error.ErrorMessage)
            );
    }
}
