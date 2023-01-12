using ArchitectureSolutions.Application.Common.Models;
using ArchitectureSolutions.Application.TodoItems.Commands.CreateTodoItem;
using ArchitectureSolutions.Application.TodoItems.Commands.DeleteTodoItem;
using ArchitectureSolutions.Application.TodoItems.Commands.PatchTodoItem;
using ArchitectureSolutions.Application.TodoItems.Commands.UpdateTodoItem;
using ArchitectureSolutions.Application.TodoItems.Commands.UpdateTodoItemDetail;
using ArchitectureSolutions.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSolutions.WebUI.Controllers;

//[Authorize]
public class TodoItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("{id}/JsonPatch")]
    public async Task<ActionResult> JsonPatch(
        int id,
        [FromBody] JsonPatchDocument patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest(ModelState);
        }
        await Mediator.Send(new JsonPatchTodoItemCommand() { Id = id, patchDoc = patchDoc });
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Patch(int id, [FromBody] PatchTodoItemDto patchTodoItem)
    {
        if (patchTodoItem == null)
        {
            return BadRequest(ModelState);
        }
        await Mediator.Send(new PatchTodoItemCommand() { Id = id, PatchTodoItem = patchTodoItem });
        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}
