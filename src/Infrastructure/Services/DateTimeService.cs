using ArchitectureSolutions.Application.Common.Interfaces;

namespace ArchitectureSolutions.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
