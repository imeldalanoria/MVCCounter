using System.Collections.Generic;
using MVCCounter.DAL;
using MVCCounter.Persistence.Repositories;

namespace MVCCounter.Service
{
    public class CounterService : ICounterService
    {
        private readonly IRepository<Count> _repository;

        public CounterService()
        {
            _repository = new Repository<Count>();
        }
        public void Add(Count entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Count> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Count entity)
        {
            _repository.Update(entity);
        }
    }
}
