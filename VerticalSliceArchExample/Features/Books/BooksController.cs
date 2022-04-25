using API.Features;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core;

namespace VerticalSliceArchExample.Features.Books;

public class BooksController : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<Add.Result>> Add(Add.Command command)
    {
        var result = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetById.Result>> GetById(int id)
    {
        try
        {
            var result = await Mediator.Send(new GetById.Query { Id = id });

            return Ok(result);
        }
        catch (ObjectNotFoundException)
        {
            return NotFound();
        }
    }
}
