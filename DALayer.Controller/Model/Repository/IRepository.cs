using System;
using System.Collections.Generic;

namespace DALayer.Controller.Model.Repository
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetList(); 
        T GetEntry(int id); 
        void Insert(T item); 
        void Update(T item); 
        void Delete(int id); 
    }
}
