using System.Collections.Generic;
using System.Linq;
using DALayer.API.DbConfiguration;
using DALayer.API.Dto;

namespace DALayer.API.Model
{
    public class Info : IDtoEntry<InfoDto>
    {
        public InfoDto GetItemById(int id, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                var item = context.InfoItems.FirstOrDefault(i => i.Id == id);
                return item;
            }
        }

        public void InsertItem(InfoDto item, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                context.InfoItems.Add(item);
                context.SaveChanges();
            }
        }

        public void UpdateItem(InfoDto item, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                var existingItem = context.InfoItems.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    existingItem.Service = item.Service;
                    existingItem.Advanced = item.Advanced;
                    existingItem.Login = item.Login;
                    existingItem.Password = item.Password;
                }
                context.SaveChanges();
            }
        }

        public void RemoveItem(int id, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                var existingItem = context.InfoItems.FirstOrDefault(i => i.Id == id);
                context.InfoItems.Remove(existingItem);
                context.SaveChanges();
            }
        }

        public List<InfoDto> GetItemsList(string searchText, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    return context.InfoItems.Where(i => i.Service.Contains(searchText)).ToList();
                }
                return context.InfoItems.ToList();
            }
        }
    }
}
