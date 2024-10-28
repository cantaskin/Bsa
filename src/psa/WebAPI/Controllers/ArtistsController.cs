using Application.Features.Artists.Commands.Create;
using Application.Features.Artists.Commands.Delete;
using Application.Features.Artists.Commands.Update;
using Application.Features.Artists.Queries.GetByIdAdminArtist;
using Application.Features.Artists.Queries.GetByIdArtist;
using Application.Features.Artists.Queries.GetDynamicList;
using Application.Features.Artists.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArtistsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedArtistResponse>> Add([FromBody] CreateArtistCommand command)
    {
        CreatedArtistResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedArtistResponse>> Update([FromBody] UpdateArtistCommand command)
    {
        UpdatedArtistResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedArtistResponse>> Delete([FromRoute] Guid id)
    {
        DeleteArtistCommand command = new() { Id = id };

        DeletedArtistResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("admin/{id}")]
    public async Task<ActionResult<GetByIdAdminArtistResponse>> GetByAdminId([FromRoute] Guid id)
    {
        GetByIdAdminArtistQuery query = new() { Id = id };

        GetByIdAdminArtistResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdArtistResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdArtistQuery query = new() { Id = id };

        GetByIdArtistResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListArtistQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListArtistQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListArtistListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("dynamicquery")]
    public async Task<ActionResult<GetDynamicListArtistQuery>> GetDynamicList([FromQuery] GetDynamicListArtistQuery query )
    {

        GetListResponse<GetDynamicListArtistListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}