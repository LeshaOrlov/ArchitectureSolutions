using ArchitectureSolutions.Application.Common.Mappings;
using ArchitectureSolutions.Domain.Entities;

namespace ArchitectureSolutions.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
