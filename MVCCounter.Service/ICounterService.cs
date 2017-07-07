using System.Collections.Generic;
using MVCCounter.DAL;

namespace MVCCounter.Service
{
    public interface ICounterService
    {
        IEnumerable<Count> GetAll();
        void Add(Count entity);
        void Update(Count entity);
    }
}
