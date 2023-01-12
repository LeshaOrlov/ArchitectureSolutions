using ArchitectureSolutions.Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureSolutions.WebUI.Controllers;
public class FileController : ApiControllerBase
{
    public FileController()
    {

    }

    [HttpPost]
    public async Task<ActionResult> CreateFile([FromForm] IFormFile file)
    {
        return Ok();
    }
}
