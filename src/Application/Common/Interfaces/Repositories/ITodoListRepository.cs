using ArchitectureSolutions.Domain.Entities;

namespace ArchitectureSolutions.Application.Common.Interfaces.Repositories;
public interface ITodoListRepository
{
    TodoList GetById(int id);
    void DeleteById(int id);
}
