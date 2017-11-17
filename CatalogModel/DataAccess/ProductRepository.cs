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
    public class ProductRepository : IRepository<Product>
    {
        private Boolean isDispose = false;
        private readonly Catalog catalogContext;

        public ProductRepository()
        {
            catalogContext = new Catalog();
        }
        public ProductRepository(Catalog _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(Product item)
        {
            catalogContext.Product.Add(item);
        }

        public void Delete(int id)
        {
            Product product = this.GetById(id);
            if (product != null)
            {
                catalogContext.Product.Remove(product);
            }
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!this.isDispose)
            {
                if (disposing)
                {
                    catalogContext.Dispose();
                }
                this.isDispose = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Product> GetAll()
        {
            return catalogContext.Product.ToList();
        }

        public Product GetById(int id)
        {
            return catalogContext.Product.FirstOrDefault(x => x.PK_ProductId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Product item)
        {
            catalogContext.Entry<Product>(item).State = EntityState.Modified;
        }
    }
}
