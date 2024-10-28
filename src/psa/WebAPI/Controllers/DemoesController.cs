using Application.Features.Demoes.Commands.Create;
using Application.Features.Demoes.Commands.Delete;
using Application.Features.Demoes.Commands.Update;
using Application.Features.Demoes.Queries.GetById;
using Application.Features.Demoes.Queries.GetDynamicList;
using Application.Features.Demoes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemoesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDemoResponse>> Add([FromBody] CreateDemoCommand command)
    {
        CreatedDemoResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDemoResponse>> Update([FromBody] UpdateDemoCommand command)
    {
        UpdatedDemoResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDemoResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDemoCommand command = new() { Id = id };

        DeletedDemoResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDemoResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDemoQuery query = new() { Id = id };

        GetByIdDemoResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListDemoQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDemoQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDemoListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("dynamicquery")]
    public async Task<ActionResult<GetDynamicListDemoQuery>> GetDynamicList([FromQuery] GetDynamicListDemoQuery query)
    {
        GetListResponse<GetDynamicListDemoListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}