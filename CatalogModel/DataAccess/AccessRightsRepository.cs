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
    public class AccessRightsRepository : IRepository<AccessRights>
    {
        private readonly Catalog catalog;
        private Boolean isDispose = false;
        public AccessRightsRepository()
        {
            catalog = new Catalog();
        }
        public AccessRightsRepository(Catalog _catalog)
        {
            this.catalog = _catalog;
        }

        public void Create(AccessRights item)
        {
            catalog.AccessRights.Add(item);
        }

        public void Delete(int id)
        {
            AccessRights accessRights = this.GetById(id);
            if (accessRights != null)
            {
                catalog.AccessRights.Remove(accessRights);
            }
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!this.isDispose)
            {
                if (disposing)
                {
                    catalog.Dispose();
                }
                this.isDispose = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AccessRights> GetAll()
        {
            return catalog.AccessRights.ToList();
        }

        public AccessRights GetById(int id)
        {
            return catalog.AccessRights.FirstOrDefault(x => x.PK_AccessRightsId == id);
        }

        public void Save()
        {
            catalog.SaveChanges();
        }

        public void Update(AccessRights item)
        {
            catalog.Entry<AccessRights>(item).State = EntityState.Modified;
        }
    }
}
