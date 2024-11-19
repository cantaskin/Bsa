using Application.Features.UsageRights.Commands.Create;
using Application.Features.UsageRights.Commands.Delete;
using Application.Features.UsageRights.Commands.Update;
using Application.Features.UsageRights.Queries.GetById;
using Application.Features.UsageRights.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsageRightsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUsageRightResponse>> Add([FromBody] CreateUsageRightCommand command)
    {
        CreatedUsageRightResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUsageRightResponse>> Update([FromBody] UpdateUsageRightCommand command)
    {
        UpdatedUsageRightResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUsageRightResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUsageRightCommand command = new() { Id = id };

        DeletedUsageRightResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUsageRightResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUsageRightQuery query = new() { Id = id };

        GetByIdUsageRightResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListUsageRightQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUsageRightQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUsageRightListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}