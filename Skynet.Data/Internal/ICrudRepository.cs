using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Data.Internal
{
    internal interface ICrudRepository<T>
    {
        void Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove();
        void Update();
    }
}
