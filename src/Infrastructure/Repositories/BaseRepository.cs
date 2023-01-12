using ArchitectureSolutions.Domain.Common;
using ArchitectureSolutions.Infrastructure.Persistence;

namespace ArchitectureSolutions.Infrastructure.Repositories;

public class BaseRepository<T>: BaseRepository<T, int>
    where T : BaseEntity
{
    public BaseRepository(ApplicationDbContext applicationDb): base(applicationDb)
    {
    }
}

public class BaseRepository<T, Tkey>
    where T : BaseEntity<Tkey>
{
    ApplicationDbContext _applicationDb;
    public BaseRepository(ApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }

    void Create(T entity)
    {
        _applicationDb.Set<T>().Add(entity);
        _applicationDb.SaveChanges();
    }

    void Update(T entity)
    {
        _applicationDb.Set<T>().Update(entity);
        _applicationDb.SaveChanges();
    }

    void Patch(T entity)
    {

    }

    void Delete(Tkey Id)
    {
        var entity = _applicationDb.Set<T>().Find(Id);
        if (entity == null)
        {
            _applicationDb.Set<T>().Remove(entity);
            _applicationDb.SaveChanges();
        }
    }
}
