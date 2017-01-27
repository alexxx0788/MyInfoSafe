using System;
using System.Collections.Generic;
using DALayer.Controller.Model.Dto;

namespace DALayer.Controller.Model.Repository
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
