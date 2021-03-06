using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories
{
    public interface IEntityRepo<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity? GetById(int id);
        Task<TEntity?> GetByIdAsync(int id);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
