using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Settings> settings = new List<Settings>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Settings { Name = "Settings1", Value = "123" });
            Add(new Settings { Name = "Settings2", Value = "456" });
        }

        public IEnumerable<Settings> GetAll()
        {
            return settings;
        }

        public Settings Get(int id)
        {
            return settings.Find(p => p.Id == id);
        }

        public Settings Add(Settings item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            settings.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            settings.RemoveAll(p => p.Id == id);
        }

        public bool Update(Settings item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = settings.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            settings.RemoveAt(index);
            settings.Add(item);
            return true;
        }
    }
}