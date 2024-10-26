using Application.Features.Languages.Commands.Create;
using Application.Features.Languages.Commands.Delete;
using Application.Features.Languages.Commands.Update;
using Application.Features.Languages.Queries.GetById;
using Application.Features.Languages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLanguageResponse>> Add([FromBody] CreateLanguageCommand command)
    {
        CreatedLanguageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLanguageResponse>> Update([FromBody] UpdateLanguageCommand command)
    {
        UpdatedLanguageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLanguageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteLanguageCommand command = new() { Id = id };

        DeletedLanguageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLanguageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLanguageQuery query = new() { Id = id };

        GetByIdLanguageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLanguageQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLanguageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}