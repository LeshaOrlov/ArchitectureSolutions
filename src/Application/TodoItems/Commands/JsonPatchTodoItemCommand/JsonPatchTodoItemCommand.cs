using ArchitectureSolutions.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace ArchitectureSolutions.Application.TodoItems.Commands.PatchTodoItem;
public class JsonPatchTodoItemCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public JsonPatchDocument patchDoc { get; set; }
}

public class JsonPatchTodoItemCommandHandler : IRequestHandler<JsonPatchTodoItemCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public JsonPatchTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(JsonPatchTodoItemCommand request, CancellationToken cancellationToken)
    {
        if (request.patchDoc != null)
        {
            var customer = _context.TodoItems.Find(request.Id);

            request.patchDoc.ApplyTo(customer);

            await _context.SaveChangesAsync(cancellationToken);

        }

        return default;
    }
}


