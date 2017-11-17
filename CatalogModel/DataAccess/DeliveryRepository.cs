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
    public class DeliveryRepository : IRepository<Delivery>
    {

        private Boolean isDispose = false;
        private readonly Catalog catalogContext;

        public DeliveryRepository()
        {
            catalogContext = new Catalog();
        }

        public DeliveryRepository(Catalog _catalog)
        {
            catalogContext = _catalog;
        }

        public void Create(Delivery item)
        {
            catalogContext.Delivery.Add(item);
        }

        public void Delete(int id)
        {
            Delivery delivery = this.GetById(id);
            if (delivery != null)
            {
                catalogContext.Delivery.Remove(delivery);
            }
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!isDispose)
            {
                if (disposing)
                {
                    catalogContext.Dispose();
                }
                isDispose = true;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Delivery> GetAll()
        {
            return catalogContext.Delivery.ToList();
        }

        public Delivery GetById(int id)
        {
            return catalogContext.Delivery.FirstOrDefault(x => x.PK_DeliveryId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Delivery item)
        {
            catalogContext.Entry<Delivery>(item).State = EntityState.Modified;
        }
    }
}
