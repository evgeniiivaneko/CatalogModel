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
    public class OrderRepository : IRepository<Order>
    {
        private readonly Catalog catalogContext;
        private Boolean isDispose = false;

        public OrderRepository()
        {
            catalogContext = new Catalog();
        }
        public OrderRepository(Catalog _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(Order item)
        {
            catalogContext.Order.Add(item);
        }

        public void Delete(int id)
        {
            Order order = this.GetById(id);
            if (order != null)
                catalogContext.Order.Remove(order);
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!this.isDispose)
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

        public IEnumerable<Order> GetAll()
        {
            return catalogContext.Order.ToList();
        }

        public Order GetById(int id)
        {
            return catalogContext.Order.FirstOrDefault(x => x.PK_OrderId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Order item)
        {
            catalogContext.Entry<Order>(item).State = EntityState.Modified;
        }
    }
}
