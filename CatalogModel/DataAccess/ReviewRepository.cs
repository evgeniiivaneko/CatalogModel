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
    public class ReviewRepository : IRepository<Review>
    {
        private readonly Catalog catalogContext;
        private Boolean isDispose = false;
        public ReviewRepository()
        {
            catalogContext = new Catalog();
        }
        public ReviewRepository(Catalog _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }
        public void Create(Review item)
        {
            catalogContext.Review.Add(item);
        }

        public void Delete(int id)
        {
            Review review = this.GetById(id);
            if (review != null)
            {
                catalogContext.Review.Remove(review);
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

        public IEnumerable<Review> GetAll()
        {
            return catalogContext.Review.ToList();
        }

        public Review GetById(int id)
        {
            return catalogContext.Review.FirstOrDefault(x => x.PK_ReviewId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Review item)
        {
            catalogContext.Entry<Review>(item).State = EntityState.Modified;
        }
    }
}
