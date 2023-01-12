using ArchitectureSolutions.Application.Common.Models;

namespace ArchitectureSolutions.Application.TodoItems.Commands.PatchTodoItem;
public class PatchTodoItemDto: PatchDtoBase
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
