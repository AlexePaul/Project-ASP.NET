using Proiect.Models.Base;

namespace Proiect.Repos.BaseRepo
{
    public interface IBaseRepo<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        Task<TEntity?> FindByIdAsync(object id);
        TEntity? FindById(object id);

        Task<bool> SaveAsync();
    }
}
