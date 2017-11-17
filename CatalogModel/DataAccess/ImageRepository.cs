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
    public class ImageRepository : IRepository<Image>
    {
        private Boolean isDispose = false;
        private readonly Catalog catalogContext;
        public ImageRepository()
        {
            catalogContext = new Catalog();
        }
        public ImageRepository(Catalog _catalogContext)
        {
            this.catalogContext = _catalogContext;
        }

        public void Create(Image item)
        {
            catalogContext.Image.Add(item);
        }

        public void Delete(int id)
        {
            Image image = this.GetById(id);
            if (image != null)
                catalogContext.Image.Remove(image);
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

        public IEnumerable<Image> GetAll()
        {
            return catalogContext.Image.ToList();
        }

        public Image GetById(int id)
        {
            return catalogContext.Image.FirstOrDefault(x => x.PK_ImageId == id);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }

        public void Update(Image item)
        {
            catalogContext.Entry<Image>(item).State = EntityState.Modified;
        }
    }
}
