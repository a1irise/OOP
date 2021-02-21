using System;
using System.Collections.Generic;

namespace lab6.DAL.Infostructure
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T Get(string id);

        void Create(T item);
        void Update(T item);
        void Delete(string id);

        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}