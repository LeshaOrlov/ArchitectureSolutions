using ArchitectureSolutions.Application.TodoLists.Queries.ExportTodos;

namespace ArchitectureSolutions.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
