namespace DAL.Repositories.Core.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> Get();
    Task<TEntity> GetById(Guid id);
    Task<bool> IsIdExists(Guid id);
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(Guid id);
}