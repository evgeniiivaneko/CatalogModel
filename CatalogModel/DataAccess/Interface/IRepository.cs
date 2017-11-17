using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.DataAccess.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();

        void Create(T item);

        void Delete(int id);

        void Update(T item);

        T GetById(int id);

        void Save();

        //void DeletAll();
    }
}
