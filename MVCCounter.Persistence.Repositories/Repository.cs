using MVCCounter.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MVCCounter.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        public Repository()
        {
            _context = new FlatPlanetEntities();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            Complete();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
            Complete();
        }
        private void Complete()
        {
            _context.SaveChanges();
        }
    }
}
