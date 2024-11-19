using Application.Features.RealVoiceProjects.Commands.Accept;
using Application.Features.RealVoiceProjects.Commands.Create;
using Application.Features.RealVoiceProjects.Commands.Delete;
using Application.Features.RealVoiceProjects.Commands.Update;
using Application.Features.RealVoiceProjects.Queries.GetById;
using Application.Features.RealVoiceProjects.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.RealVoiceProjects.Commands.Reject;
using Application.Features.RealVoiceProjects.Commands.Finalize;
using Application.Features.RealVoiceProjects.Commands.RevisionNeed;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RealVoiceProjectsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRealVoiceProjectResponse>> Create([FromBody] CreateRealVoiceProjectCommand command)
    {
        CreatedRealVoiceProjectResponse response = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPost("accept")]
    public async Task<ActionResult<AcceptedRealVoiceProjectResponse>> Accept([FromBody] AcceptRealVoiceProjectCommand command)
    {
        AcceptedRealVoiceProjectResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("reject")]
    public async Task<ActionResult<RejectedRealVoiceProjectResponse>> Reject([FromBody] RejectRealVoiceProjectCommand command)
    {
        RejectedRealVoiceProjectResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("finalize")]
    public async Task<ActionResult<FinalizedRealVoiceProjectResponse>> Finalize([FromBody] FinalizeRealVoiceProjectCommand command)
    {
        FinalizedRealVoiceProjectResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("revision")]
    public async Task<ActionResult<RevisionNeededRealVoiceProjectResponse>> MarkAsRevisionNeeded([FromBody] RevisionNeedRealVoiceProjectCommand command)
    {
        RevisionNeededRealVoiceProjectResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdatedRealVoiceProjectResponse>> Update([FromBody] UpdateRealVoiceProjectCommand command)
    {
        UpdatedRealVoiceProjectResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRealVoiceProjectResponse>> Delete([FromRoute] Guid id)
    {
        DeleteRealVoiceProjectCommand command = new() { Id = id };
        DeletedRealVoiceProjectResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRealVoiceProjectResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRealVoiceProjectQuery query = new() { Id = id };
        GetByIdRealVoiceProjectResponse response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("list")]
    public async Task<ActionResult<GetListResponse<GetListRealVoiceProjectListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRealVoiceProjectQuery query = new() { PageRequest = pageRequest };
        GetListResponse<GetListRealVoiceProjectListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}
