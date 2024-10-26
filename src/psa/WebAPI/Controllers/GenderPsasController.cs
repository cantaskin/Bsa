using Application.Features.GenderPsas.Commands.Create;
using Application.Features.GenderPsas.Commands.Delete;
using Application.Features.GenderPsas.Commands.Update;
using Application.Features.GenderPsas.Queries.GetById;
using Application.Features.GenderPsas.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenderPsasController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGenderPsaResponse>> Add([FromBody] CreateGenderPsaCommand command)
    {
        CreatedGenderPsaResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedGenderPsaResponse>> Update([FromBody] UpdateGenderPsaCommand command)
    {
        UpdatedGenderPsaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGenderPsaResponse>> Delete([FromRoute] Guid id)
    {
        DeleteGenderPsaCommand command = new() { Id = id };

        DeletedGenderPsaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGenderPsaResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdGenderPsaQuery query = new() { Id = id };

        GetByIdGenderPsaResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListGenderPsaQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGenderPsaQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGenderPsaListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}