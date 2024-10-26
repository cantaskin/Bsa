using Application.Features.ToneCategories.Commands.Create;
using Application.Features.ToneCategories.Commands.Delete;
using Application.Features.ToneCategories.Commands.Update;
using Application.Features.ToneCategories.Queries.GetById;
using Application.Features.ToneCategories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToneCategoriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedToneCategoryResponse>> Add([FromBody] CreateToneCategoryCommand command)
    {
        CreatedToneCategoryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedToneCategoryResponse>> Update([FromBody] UpdateToneCategoryCommand command)
    {
        UpdatedToneCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedToneCategoryResponse>> Delete([FromRoute] Guid id)
    {
        DeleteToneCategoryCommand command = new() { Id = id };

        DeletedToneCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdToneCategoryResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdToneCategoryQuery query = new() { Id = id };

        GetByIdToneCategoryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListToneCategoryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListToneCategoryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListToneCategoryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}