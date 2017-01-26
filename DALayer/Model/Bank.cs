using System;
using System.Collections.Generic;
using System.Linq;
using DALayer.API.DbConfiguration;
using DALayer.API.Dto;

namespace DALayer.API.Model
{
    public class Bank : IDtoEntry<BankDto>
    {
        public BankDto GetItemById(int id, string password)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(password)))
            {
                var item = context.Banks.FirstOrDefault(i => i.Id == id);
                return item;
            }
        }

        public void InsertItem(BankDto item, string password)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(password)))
            {
                item.StartDate=DateTime.Today;
                item.EndDate = DateTime.Today;
                context.Banks.Add(item);
                context.SaveChanges();
            }
        }

        public void UpdateItem(BankDto item, string password)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(password)))
            {
                var existingItem = context.Banks.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    existingItem.BankName = item.BankName;
                    existingItem.Comment = item.Comment;
                   // existingItem.EndDate = item.EndDate;
                    //existingItem.StartDate = item.StartDate;
                   // existingItem.Month = item.Month;
                  //  existingItem.Persent = item.Persent;
                    existingItem.Summ = item.Summ;
                  //  existingItem.Type = item.Type;
                }
                context.SaveChanges();
            }
        }

        public void RemoveItem(int id, string password)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(password)))
            {
                var existingItem = context.Banks.FirstOrDefault(i => i.Id == id);
                context.Banks.Remove(existingItem);
                context.SaveChanges();
            }
        }

        public List<BankDto> GetItemsList(string searchText, string password)
        {
            using (var context = new InfoSafeContext(SqlCeConfiguration.GetConnectString(password)))
            {
                var currs = context.Banks;
                if (!string.IsNullOrEmpty(searchText))
                {
                    return currs.Where(i => i.BankName.Contains(searchText)).ToList();
                }
                return currs.ToList();
            }
        }
    }
}
