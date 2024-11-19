using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBlogResponse>> Add([FromBody] CreateBlogCommand command)
    {
        CreatedBlogResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBlogResponse>> Update([FromBody] UpdateBlogCommand command)
    {
        UpdatedBlogResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBlogResponse>> Delete([FromRoute] Guid id)
    {
        DeleteBlogCommand command = new() { Id = id };

        DeletedBlogResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBlogResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdBlogQuery query = new() { Id = id };

        GetByIdBlogResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBlogQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlogQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBlogListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}