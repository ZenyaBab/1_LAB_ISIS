using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    interface IProductRepository
    {
        IEnumerable<Settings> GetAll();
        Settings Get(int id);
        Settings Add(Settings item);
        void Remove(int id);
        bool Update(Settings item);
    }
}
