using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogModel.DataAccess;
using CatalogModel.Model;

namespace CatalogModel.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private Boolean isDispose = false;
        private readonly Catalog catalogContext;
        private AccessRightsRepository accessRights;
        private BrandRepository brand;
        private ConditionerRepository conditioner;
        private ImageRepository image;
        private OrderRepository order;
        private ProductRepository product;
        private ReviewRepository review;
        private TypeRepository type;
        private UserRepository user;
        public UnitOfWork()
        {
            catalogContext = new Catalog();
        }

        public AccessRightsRepository AccessRights
        {
            get
            {
                if (accessRights == null)
                    accessRights = new AccessRightsRepository(catalogContext);
                return accessRights;
            }

        }
        public BrandRepository Brand
        {
            get
            {
                if (brand == null)
                    brand = new BrandRepository(catalogContext);
                return brand;
            }
        }
        public ConditionerRepository Conditioner
        {
            get
            {
                if (conditioner == null)
                    conditioner = new ConditionerRepository(catalogContext);
                return conditioner;
            }
        }
        public ImageRepository Image
        {
            get
            {
                if (image == null)
                    image = new ImageRepository(catalogContext);
                return image;
            }
        }
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(catalogContext);
                return order;
            }
        }
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(catalogContext);
                return product;
            }
        }
        public ReviewRepository Review
        {
            get
            {
                if (review == null)
                    review = new ReviewRepository(catalogContext);
                return review;
            }
        }
        public TypeRepository Type
        {
            get
            {
                if (type == null)
                    type = new TypeRepository(catalogContext);
                return type;
            }
        }
        public UserRepository User
        {
            get
            {
                if (user == null)
                    user = new UserRepository(catalogContext);
                return user;
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
            this.Save();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            catalogContext.SaveChanges();
        }
    }
}
