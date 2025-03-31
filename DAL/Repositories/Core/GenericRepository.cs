using DAL.Repositories.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Core;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly DatabaseContext DatabaseContext;
    protected readonly DbSet<TEntity> Table;

    protected GenericRepository(DatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
        Table = DatabaseContext.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> Get() => await Table.ToListAsync();

    public virtual async Task<TEntity> GetById(Guid id) => (await Table.FindAsync(id))!;
    public virtual async Task<bool> IsIdExists(Guid id) => await Table.FindAsync(id) != null;

    public virtual async Task Create(TEntity entity) => await Table.AddAsync(entity);

    public virtual async Task Update(TEntity entity) => await Task.Run(() => Table.Update(entity));

    public virtual async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        await Task.Run(() => Table.Remove(entity));
    }
}