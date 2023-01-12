using ArchitectureSolutions.Application.Common.Extensions;
using ArchitectureSolutions.Application.Common.Interfaces;
using MediatR;

namespace ArchitectureSolutions.Application.TodoItems.Commands.PatchTodoItem;
public record PatchTodoItemCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public PatchTodoItemDto PatchTodoItem { get; set; }
}

/// <summary>
/// Handler
/// </summary>
public record PatchTodoItemCommandHandler : IRequestHandler<PatchTodoItemCommand, Unit>
{
    private readonly IApplicationDbContext _context;
    public PatchTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PatchTodoItemCommand request, CancellationToken cancellationToken)
    {
        if (request.PatchTodoItem != null)
        {
            var customer = _context.TodoItems.Find(request.Id);

            request.PatchTodoItem.ApplyTo(customer);

            await _context.SaveChangesAsync(cancellationToken);
        }

        return default;
    }
}
