using Application.Features.BlogCategories.Commands.Create;
using Application.Features.BlogCategories.Commands.Delete;
using Application.Features.BlogCategories.Commands.Update;
using Application.Features.BlogCategories.Queries.GetById;
using Application.Features.BlogCategories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogCategoriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBlogCategoryResponse>> Add([FromBody] CreateBlogCategoryCommand command)
    {
        CreatedBlogCategoryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBlogCategoryResponse>> Update([FromBody] UpdateBlogCategoryCommand command)
    {
        UpdatedBlogCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBlogCategoryResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBlogCategoryCommand command = new() { Id = id };

        DeletedBlogCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBlogCategoryResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBlogCategoryQuery query = new() { Id = id };

        GetByIdBlogCategoryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBlogCategoryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlogCategoryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBlogCategoryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}