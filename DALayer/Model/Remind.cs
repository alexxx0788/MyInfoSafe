using System.Collections.Generic;
using System.Linq;
using DALayer.API.DbConfiguration;
using DALayer.API.Dto;

namespace DALayer.API.Model
{
    public class Remind : IDtoEntry<RemindDto>
    {
        public RemindDto GetItemById(int id,string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                var item = context.Reminds.FirstOrDefault(i => i.Id == id);
                return item;
            }
        }

        public void InsertItem(RemindDto item, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                context.Reminds.Add(item);
                context.SaveChanges();
            }
        }

        public void UpdateItem(RemindDto item, string passowrd)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(passowrd)))
            {
                var existingItem = context.Reminds.FirstOrDefault(i => i.Id == 1);
                if (existingItem != null)
                {
                    existingItem.Address = item.Address;
                    existingItem.Count = item.Count;
                    existingItem.EmailAccount = item.EmailAccount;
                    existingItem.Password = item.Password;
                    existingItem.Port = item.Port;
                    existingItem.Smtp = item.Smtp;
                    existingItem.ToAddress = item.ToAddress;
                }
                context.SaveChanges();
            }
        }

        public void RemoveItem(int id, string passowrd)
        {
            //
        }

        public List<RemindDto> GetItemsList(string searchText, string passowrd)
        {
            return null;
        }

    }
}
