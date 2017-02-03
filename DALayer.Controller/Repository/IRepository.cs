using System;
using System.Collections.Generic;

namespace IStor.DAL.Model.Repository
{
    interface IRepository<T> : IDisposable where T:class
    {
        IEnumerable<T> GetList(string service); 
        T GetEntry(int id); 
        bool Insert(T item); 
        bool Update(T item,int id); 
        bool Delete(int id); 
    }
}
