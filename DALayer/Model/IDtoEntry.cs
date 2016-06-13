using System;
using System.Collections.Generic;

namespace DALayer.API.Model
{
    interface IDtoEntry<T>
    {
        List<T> GetItemsList(string searchText,string password);
        T GetItemById(int id, string password);
        void InsertItem(T item, string password);
        void UpdateItem(T item,string password);
        void RemoveItem(int id, string password);
    }

}
