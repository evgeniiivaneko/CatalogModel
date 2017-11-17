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
    public class ConditionerRepository : IRepository<Conditioner>
    {
        private readonly Catalog Catalog;
        private Boolean isDispose = false;
        public ConditionerRepository()
        {
            Catalog = new Catalog();
        }
        public ConditionerRepository(Catalog _catalog)
        {
            this.Catalog = _catalog;
        }

        public void Create(Conditioner item)
        {
            Catalog.Conditioner.Add(item);
        }

        public void Delete(int id)
        {
            Conditioner conditioner = this.GetById(id);
            if (conditioner != null)
            {
                Catalog.Conditioner.Remove(conditioner);
            }
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!isDispose)
            {
                if (disposing)
                {
                    Catalog.Dispose();
                }
                isDispose = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Conditioner> GetAll()
        {
            return Catalog.Conditioner.ToList();
        }

        public Conditioner GetById(int id)
        {
            return Catalog.Conditioner.FirstOrDefault(x => x.FK_ProductId == id);
        }

        public void Save()
        {
            Catalog.SaveChanges();
        }

        public void Update(Conditioner item)
        {
            Catalog.Entry<Conditioner>(item).State = EntityState.Modified;
        }
    }
}
