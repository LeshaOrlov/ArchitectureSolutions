using ArchitectureSolutions.Application.Common.Mappings;
using ArchitectureSolutions.Domain.Entities;

namespace ArchitectureSolutions.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
