using System;
using System.Collections.Generic;
using System.Text;

namespace OficinaMVVM.Services
{
    public interface IDataStore<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(long? id);
        IEnumerable<T> GetAll();

    }
}
