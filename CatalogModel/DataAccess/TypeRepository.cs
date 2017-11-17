using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogModel.Model;
using CatalogModel.DataAccess.Interface;
using System.Data.Entity;

namespace CatalogModel.DataAccess
{
    public class TypeRepository : IRepository<CatalogModel.Model.Type>
    {
        private Boolean idDisposed = false;
        private readonly Catalog catalogContext;

        public TypeRepository()
        {
            catalogContext = new Catalog();
        }

        public TypeRepository(Catalog _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(CatalogModel.Model.Type item)
        {
            catalogContext.Type.Add(item);
        }

        public void Delete(int id)
        {
            CatalogModel.Model.Type type = this.GetById(id);
            if (type != null)
            {
                catalogContext.Type.Remove(type);
            }
        }
        /// <summary>
        /// Метод для закрытия подключения к базе данных
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(Boolean disposing)
        {
            if (!this.idDisposed)
            {
                if (disposing)
                {
                    catalogContext.Dispose();
                }
            }
            this.idDisposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CatalogModel.Model.Type> GetAll()
        {
            return catalogContext.Type.ToList();
        }

        public CatalogModel.Model.Type GetById(int id)
        {
            return catalogContext.Type.FirstOrDefault(x => x.PK_TypeId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(CatalogModel.Model.Type item)
        {
            catalogContext.Entry(item).State = EntityState.Modified;
        }
    }
}
