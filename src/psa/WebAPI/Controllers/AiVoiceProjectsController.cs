using Application.Features.AiVoiceProjects.Commands.Create;
using Application.Features.AiVoiceProjects.Commands.Delete;
using Application.Features.AiVoiceProjects.Commands.Update;
using Application.Features.AiVoiceProjects.Queries.GetById;
using Application.Features.AiVoiceProjects.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AiVoiceProjectsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAiVoiceProjectResponse>> Add([FromBody] CreateAiVoiceProjectCommand command)
    {
        CreatedAiVoiceProjectResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAiVoiceProjectResponse>> Update([FromBody] UpdateAiVoiceProjectCommand command)
    {
        UpdatedAiVoiceProjectResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAiVoiceProjectResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAiVoiceProjectCommand command = new() { Id = id };

        DeletedAiVoiceProjectResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAiVoiceProjectResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAiVoiceProjectQuery query = new() { Id = id };

        GetByIdAiVoiceProjectResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAiVoiceProjectQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAiVoiceProjectQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAiVoiceProjectListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}