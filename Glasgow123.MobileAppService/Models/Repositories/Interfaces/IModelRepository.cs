using System;
using System.Collections.Generic;

namespace Glasgow123.Models
{
    public interface IModelRepository<T>
    {
        void Add(T item);
        void Update(T item);
        T Remove(int key);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
